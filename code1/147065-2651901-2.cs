    var regex = new Regex(@"(?:\s*\[((.*?)(?:,(.+?))*)\])+");
    var match = regex.Match(@"[1,2,3,4,5] [abc,ef,g] [0,2,4b,y7]");
    for (var i = 1; i < match.Groups.Count; i++)
    {
        var group = match.Groups[i];
        Console.WriteLine("Group " + i);
			
        for (var j = 0; j < group.Captures.Count; j++)
        {
            var capture = group.Captures[j];
				
            Console.WriteLine("  Capture " + j + ": " + capture.Value 
                                           + " at " + capture.Index);
        }
    }
