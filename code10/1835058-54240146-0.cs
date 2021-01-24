        string source = "\"kk\"jlu,fhhfh,hrhrh,rhrhr";
        List<string> data = new List<string>();
        var parts = source.Split('\"');
        data.AddRange(parts.Where((x, index) => index % 2 != 0));
        parts.Where((x, index) => index % 2 == 0)
            .ToList()
            .ForEach(x => data.AddRange(x.Split(',')));
        var result = string.Join(" | ", data.Where(x => !string.IsNullOrWhiteSpace(x)));
        Console.WriteLine(result);
