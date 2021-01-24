    string[] lines = new[] {
        "Microsoft.MicrosoftJigsaw     All",
        "Microsoft.MicrosoftMahjong            All"
    };
    foreach (var line in lines)
    {
        string[] splitted = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Trace.WriteLine( splitted[0].PadRight(40, ' ') + splitted[1]);
    }
