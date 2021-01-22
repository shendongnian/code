        var result = new Regex(@"(\S.+?[.!?])(?=\s+|$)(?<!\s([A-Z]|[a-z]){1,3}.)").Split(input).Where(s => !String.IsNullOrWhiteSpace(s)).ToArray<string>();
        foreach (var match in result) 
        {
            Console.WriteLine(match);
        }
    
