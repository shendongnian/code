`
static string FormatJsonText(string jsonString)
{
	using var doc = JsonDocument.Parse(
		jsonString,
		new JsonDocumentOptions
		{
			AllowTrailingCommas = true
		}
	);
	MemoryStream memoryStream = new MemoryStream();
	using (
		var utf8JsonWriter = new Utf8JsonWriter(
			memoryStream,
			new JsonWriterOptions
			{
				Indented = true
			}
		)
	)
	{
		doc.WriteTo(utf8JsonWriter);
	}
	return new System.Text.UTF8Encoding()
		.GetString(memoryStream.GetBuffer());
}
`
