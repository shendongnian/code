    response.Content =
    	new PushStreamContent((stream, content, context) =>
    	{
			using (var sw = new StreamWriter(stream))
			using (var jsonWriter = new JsonTextWriter(sw))
			{
    			jsonWriter.WriteStartObject();
    			{
    				jsonWriter.WritePropertyName("response");
    				jsonWriter.WriteStartArray();
					{
						foreach (var item in ps)
						{
							var jObject = JObject.FromObject(item);
							jObject.WriteTo(jsonWriter);
						}
					}
					jsonWriter.WriteEndArray();
    			}
    			jsonWriter.WriteEndObject();
    		}
    	});
