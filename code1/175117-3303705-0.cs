    var output = args.Select((value, idx) => new { Value = value, Group = idx / 2 })
                .GroupBy(x => x.Group)
                .Select(g => new 
                 { 
                     Command = g.First().Value, 
                     Argument = g.Last().Value 
                 })
                .Aggregate(
                    new StringBuilder(), 
                    (builder, value) => 
                    { 
                        builder.AppendLine(commands[value.Command](value.Argument)); 
                        return builder; 
                    }).ToString();
