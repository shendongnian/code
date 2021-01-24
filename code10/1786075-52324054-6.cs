    var sampleCount = 100; // Or whatever
    var sampleInterval = 10;
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
        var query = Enumerable.Range(0, sampleCount)
            .Select(i =>
            {
                // Flush the writer periodically to ensure that as much data as possible is written
                // in case the process is terminated.
                jsonWriter.Flush();
                Thread.Sleep(sampleInterval);
                Console.WriteLine("Performing sample {0} of {1}", i, sampleCount);
                return GetPressureMap(i);
            });
        var recordedData = new RecordedData
        {
            RecordedDataHeader = recordedDataHeader,
            // Since PressureData is declared as IEnumerable<PressureMap>, evaluation of query will be lazy.
            PressureData = query,
        };
        Console.WriteLine("Beginning serialization of {0} to {1}:", recordedData, this.filePath);
        JsonSerializer.CreateDefault(settings).Serialize(textWriter, recordedData);
        Console.WriteLine("Finished serialization of {0} to {1}.", recordedData, this.filePath);
    }
