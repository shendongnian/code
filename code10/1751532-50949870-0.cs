    var lines = new List<string>();
    var lineNum = 0;
    foreach(var word in words)
    {
        if(lines[lineNum].Length + word.Length + 1 <= 20)
            lines[lineNum] += " " + word;
        else
        {
            lines.Add(word);
            lineNum++;
        }
    }
