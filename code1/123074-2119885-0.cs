using(var xr = XmlReader.Create(input))
{
	while(xr.Read())
	{
		if(xr.NodeType == XmlNodeType.ProcessingInstruction && xr.Name == "xml-stylesheet")
		{
			string s = xr.Value;
			int i = s.IndexOf("href=\"") + 6;
			s = s.Substring(i, s.IndexOf('\"', i) - i);
			Console.WriteLine(s);
			break;
		}
	}
}
