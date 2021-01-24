	static bool TryDeserialize<TRootObject>(string jsonString, out TRootObject root)
	{
		var errorStack = new Stack<Newtonsoft.Json.Serialization.ErrorEventArgs>();
		var settings = new JsonSerializerSettings
		{
			Converters = { new StringEnumConverter() },
			Error = (o, e) => errorStack.Push(e)
		};
		try
		{
			root = JsonConvert.DeserializeObject<TRootObject>(jsonString, settings);
			return true;
		}
		catch (JsonException ex)
		{
			var last = errorStack.Last();
			var member = last.ErrorContext.Member;
			var path = last.ErrorContext.Path;
			var objectsStack = String.Join(", ", errorStack
										   .Where(e => e.CurrentObject != null)
										   .Select(e => e.CurrentObject.ToString()));
			Console.WriteLine("Exception parsing JSON: ");
			Console.WriteLine(ex.Message);
			Console.WriteLine("Error context details: ");
			Console.WriteLine("   Path: {0}\n   Member: {1}\n   object stack = {{{2}}}", 
							  path, member, ObjectsStack);
			root = default(TRootObject);
			return false;
		}
	}	
