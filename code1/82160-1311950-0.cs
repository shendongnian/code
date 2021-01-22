    protected string SerializeToJson(List<string[]> list) {
			if ( list != null && list.Count > 0 ) {
				var stream = new MemoryStream();
				var jsSerializer = new DataContractJsonSerializer(list.GetType());
				jsSerializer.WriteObject(stream, list);
				return Encoding.UTF8.GetString(stream.ToArray());
			}
			return string.Empty;
		}
