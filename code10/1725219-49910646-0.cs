    var gems = new List<string>
    {
        "ruby",
        "emerald",
        // ...
    }
    var answer = 
        gems.Where(gem => gem == want)
            .Select(gem => $"Your wedding ring will feature your selection: {want}")
            .DefaultIfEmpty("Im sorry that was not a valid selection.");
    Console.WriteLine(answer);
