	public string MagicFunction(string str, string prefix)
	{
		using(StringWriter writer = new StringWriter())
		using(StringReader reader = new StringReader(str))
		{
			string line;
			while((line = reader.ReadLine()) != null)
			{
				writer.WriteLine(prefix + line);
			}
			return writer.ToString();
		}
	}
