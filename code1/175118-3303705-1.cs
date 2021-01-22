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
                        builder.AppendLine(
                        commands.SelectMany(kvp => kvp.Key).Contains(value.Command) ? 
                            commands.First(kvp => kvp.Key.Contains(value.Command))
                                    .Value(value.Argument)
                            : "COMMAND NOT FOUND"); 
                        return builder; 
                    }).ToString();
