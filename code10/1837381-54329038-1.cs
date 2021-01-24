    string[] lines = new[] 
    {
        "Microsoft.MicrosoftJigsaw     All",
        "Microsoft.MicrosoftMahjong            All"
    };
    // iterate all (example) lines
    foreach (var line in lines)
    {
        // split the string on spaces and remove empty ones 
        // (so multiple spaces are ignored)
        // ofcourse, you must check if the splitted array has atleast 2 elements.
        string[] splitted = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        // reformat the string, with padding the first string to a total of 40 chars.
        var formatted = splitted[0].PadRight(40, ' ') + splitted[1];
        // write to anything as output.
        Trace.WriteLine(formatted);
    }
