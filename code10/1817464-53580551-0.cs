    var dictionary = File.ReadAllLines(yourFilePath)
    					.Select(i => i.Split(new[] { " = \"" }, StringSplitOptions.RemoveEmptyEntries))
    					.ToDictionary(i => i[0], j => j[1].TrimEnd('\"'));
    					
    string globalization = dictionary["Globalization"];
