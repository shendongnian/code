    var items = File.ReadAllText(FilePath)
        .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
        .Select(line => line.Split(':'))
        .Select(pieces => new { 
            Proxy = pieces[0], 
            Port = int.Parse(pieces[1]) 
        });
