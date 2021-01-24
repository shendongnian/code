		XmlDocument doc = new XmlDocument();
		doc.LoadXml(sss);
		
		XmlNodeList root = doc.GetElementsByTagName("trkpt");
		Console.WriteLine(root.Count);
			
		for (int i = 0; i < root.Count; i++)
		{
			Console.WriteLine("attr:" +root[i].Attributes["lat"].Value);
			Console.WriteLine("attr:" +root[i].Attributes["lon"].Value);
			Console.WriteLine("subnode:" +root[i].SelectNodes("./*")[0].InnerText);
			Console.WriteLine("subnode:" +root[i].SelectNodes("./*")[1].InnerText);
			Console.WriteLine("----");
		}
