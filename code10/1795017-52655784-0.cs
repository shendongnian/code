	public static void Main()
	{
		var xml = @"<doc><ID_1>
         </ID_1>
         <ID_2>
         </ID_2>
         <ID_3>
         </ID_3></doc>";
		
		XElement el = XElement.Parse(xml);
		foreach (var e in el.Elements())
		{
			var id = e.Name.LocalName.Split('_')[1];
			e.Value = GetLinesById(id);
		}
		Console.WriteLine(el.ToString());
	}
	
	private static string GetLinesById(string id)
	{
		var sb = new StringBuilder();
		if (id == "1")
		{
			sb.AppendLine("Line 1");
		}
		else if (id == "2")
		{
			sb.AppendLine("Line 1");
			sb.AppendLine("Line 2");
		}
		else if (id == "3")
		{
			sb.AppendLine("Line 1");
			sb.AppendLine("Line 2");
			sb.AppendLine("Line 3");
		}
	
		return sb.ToString();
		
	}
