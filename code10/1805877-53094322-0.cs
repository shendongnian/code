    var table = document.DocumentNode.Descendants("tr").Where(node => node.Attributes.Contains("role")).ToList();
		foreach (var row in table)
		{
			Console.WriteLine(row.InnerText);
		}
