    var sampleCount = 400;    // Or whatever stopping criterion you prefer
    var sampleInterval = 10;  // in ms
	using (var pressureData = new BlockingCollection<PressureMap>())
	{
		// Adapted from
		// https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/blockingcollection-overview
		// https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.blockingcollection-1?view=netframework-4.7.2
		// Spin up a Task to sample the pressure maps
	    using (Task t1 = Task.Factory.StartNew(() =>
		{
			for (int i = 0; i < sampleCount; i++)
			{
				var data = GetPressureMap(i);
				Console.WriteLine("Generated sample {0}", i);
				pressureData.Add(data);
				System.Threading.Thread.Sleep(sampleInterval);
			}
			pressureData.CompleteAdding();
		}))
		{
			// Spin up a Task to consume the BlockingCollection
			using (Task t2 = Task.Factory.StartNew(() =>
			{
				var recordedDataHeader = new RecordedDataHeader
				{
					SoftwareVersion = softwareVersion,
					CalibrationConfiguration = calibrationConfiguration,
					RepresentationConfiguration = representationConfiguration,
				};
				var settings = new JsonSerializerSettings
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver(),
				};
				using (var stream = new FileStream(this.filePath, FileMode.Create))
				using (var textWriter = new StreamWriter(stream))
				using (var jsonWriter = new JsonTextWriter(textWriter))
				{
					int j = 0;
					
					var query = pressureData
						.GetConsumingEnumerable()
						.Select(p => 
								{ 
									// Flush the writer periodically in case the process terminates abnormally
									jsonWriter.Flush();
									Console.WriteLine("Serializing item {0}", j++);
									return p;
								});
					
					var recordedData = new RecordedData
					{
						RecordedDataHeader = recordedDataHeader,
						// Since PressureData is declared as IEnumerable<PressureMap>, evaluation will be lazy.
						PressureData = query,
					};							
					Console.WriteLine("Beginning serialization of {0} to {1}:", recordedData, this.filePath);
					JsonSerializer.CreateDefault(settings).Serialize(textWriter, recordedData);
					Console.WriteLine("Finished serialization of {0} to {1}.", recordedData, this.filePath);
				}
			}))
			{
				Task.WaitAll(t1, t2);
			}
		}
	}
