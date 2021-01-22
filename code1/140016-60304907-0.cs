    public static class XMLFunctions
    {		
		public static List<Tuple<string, string>> GetXMlTagsAndValues(string xml)
		{
			var xmlList = new List<Tuple<string, string>>();
			var doc = XDocument.Parse(xml);
			foreach (var element in doc.Descendants())
			{
				// we don't care about the parent tags
				if (element.Descendants().Count() > 0)
				{
					continue;
				}
				var path = element.AncestorsAndSelf().Select(e => e.Name.LocalName).Reverse();
				var xPath = string.Join("/", path); 
				xmlList.Add(Tuple.Create(xPath, element.Value));
			}
			return xmlList;
		}
		public static System.Data.DataTable CreateDataTableFromXmlFile(string xmlFilePath)
		{
			System.Data.DataTable Dt = new System.Data.DataTable();
			string input = File.ReadAllText(xmlFilePath);
			var xmlTagsAndValues = GetXMlTagsAndValues(input);
			var columnList = new List<string>();
			foreach(var xml in xmlTagsAndValues)
			{
				if(!columnList.Contains(xml.Item1))
				{
					columnList.Add(xml.Item1);
					Dt.Columns.Add(xml.Item1, typeof(string));
				}                    
			}
			DataRow dtrow = Dt.NewRow();
			var columnList2 = new Dictionary<string, string>(); 
			foreach (var xml in xmlTagsAndValues)
			{
				if (!columnList2.Keys.Contains(xml.Item1))
				{
					dtrow[xml.Item1] = xml.Item2;
					columnList2.Add(xml.Item1, xml.Item2);
				}
				else
				{   // Here we are using the same column but appending the next value
					dtrow[xml.Item1] = columnList2[xml.Item1] + "," + xml.Item2;
					columnList2[xml.Item1] = columnList2[xml.Item1] + "," + xml.Item2;
				}
			}
			Dt.Rows.Add(dtrow);
			return Dt;
		}
	}
