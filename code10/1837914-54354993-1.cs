	public static partial class JsonExtensions
	{
		// Adapted from this answer https://stackoverflow.com/a/30329731
		// To https://stackoverflow.com/q/2661063
		// By Duncan Smart https://stackoverflow.com/users/1278/duncan-smart
		
		public static string JsonPrettify(string json, Formatting formatting = Formatting.Indented)
		{
			using (var stringReader = new StringReader(json))
			using (var stringWriter = new StringWriter())
			{
				return JsonPrettify(stringReader, stringWriter, formatting).ToString();
			}
		}
		
		public static TextWriter JsonPrettify(TextReader textReader, TextWriter textWriter, Formatting formatting = Formatting.Indented)
		{
			// Let caller who allocated the the incoming readers and writers dispose them also
			// Disable date recognition since we're just reformatting
			using (var jsonReader = new JsonTextReader(textReader) { DateParseHandling = DateParseHandling.None, CloseInput = false })
			using (var jsonWriter = new JsonTextWriter(textWriter) { Formatting = formatting, CloseOutput = false })
			{
				jsonWriter.WriteToken(jsonReader);
			}
			return textWriter;
		}
	}
