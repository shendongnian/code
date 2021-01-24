	public string SerializeNode(TreeNode node)
	{
		var formatter = new SoapFormatter();
		using (var stream = new MemoryStream())
		{
			formatter.Serialize(stream, node);
			stream.Position = 0;
			using (var reader = new StreamReader(stream))
			{
				var serialized = reader.ReadToEnd();
				return serialized;
			}
		}
	}
	public TreeNode DeserializeNode(string nodeString)
	{
		var formatter = new SoapFormatter();
		using (var stream = new MemoryStream())
		{
			using (var writer = new StreamWriter(stream))
			{
				writer.Write(nodeString);
				writer.Flush();
				stream.Position = 0;
				var node = (TreeNode)formatter.Deserialize(stream);
				return node;
			}                
		}          
	}
