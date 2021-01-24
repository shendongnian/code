    var data = File.ReadAllText(intputFileName);
    var list = data.Split(new[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);
    StringBuilder strBuilder = new StringBuilder($"{list.First()}{Environment.NewLine}");
    	
    foreach(var line in list.Skip(1))
    {
    		var totalAcc = line.Split(new[]{"|"},StringSplitOptions.RemoveEmptyEntries)[2];
    		strBuilder.AppendLine($"{line}{totalAcc}");
    }
    	
    File.WriteAllText(outputFileName,strBuilder.ToString());
