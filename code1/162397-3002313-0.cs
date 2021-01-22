    var options = Colours.Blue | Colours.Green;
            
    var matching = Enum.GetValues(typeof(Colours))
                       .Cast<Colours>()
                       .Where(c => (options & c) == c)    // or use HasFlag in .NET4
                       .ToArray();
    var myEnum = matching[new Random().Next(matching.Length)];
