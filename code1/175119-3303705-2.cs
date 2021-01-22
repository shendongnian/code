    var output = args.Select((value, idx) => new { Value = value, Group = idx / 2 })
                .GroupBy(x => x.Group)
                .Select(g => new 
                 { 
                     Command = commands.FirstOrDefault(kvp => 
                        kvp.Key.Contains(g.First().Value)).Value, 
                     Argument = g.Last().Value 
                 })
                .Where(c => c.Command != null)
                .Aggregate(
                    new StringBuilder(), 
                    (builder, value) => 
                    { 
                        builder.AppendLine(value.Command(value.Argument)); 
                        return builder; 
                    }).ToString();
