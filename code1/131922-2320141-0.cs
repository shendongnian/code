    var wordsPerLine = from line in File.ReadAllLines(filename)
                   select string.Split(line, '\t');
    foreach(var line in wordsPerLine)
    {
        foreach(word in line)
        {
            // process word...
        }
    }
