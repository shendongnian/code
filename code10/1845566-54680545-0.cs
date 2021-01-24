    var result = names
        .Select(name => 
            name.Select((_, i) => name.Remove(i, 1))
                .Reverse()
                .Concat(new[] { name })
                .ToList())
        .ToList();
