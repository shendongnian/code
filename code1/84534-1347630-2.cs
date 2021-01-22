install-package YamlDotNet
		private static void DumpAsYaml(object o)
		{
			var stringBuilder = new StringBuilder();
			var serializer = new Serializer();
			serializer.Serialize(new IndentedTextWriter(new StringWriter(stringBuilder)), o);
			Console.WriteLine(stringBuilder);
		}
