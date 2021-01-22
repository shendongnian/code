        string line = "No.123456789  04/09/2009  999";
        Regex regex = 
            new Regex(@"(?<number>[\d]{9})  (?<date>[\d]{2}/[\d]{2}/[\d]{4})  (?<code>.*)");
        
        GroupCollection groups = regex.Match(line).Groups;
        var grpNames = regex.GetGroupNames();
        foreach (var grpName in grpNames)
        {
            Console.WriteLine("Group: {0}, Value: {1}", grpName, groups[grpName].Value);
        }
