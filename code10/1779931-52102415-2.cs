    string input = "Apple   :   100";
    Stopwatch sw = new Stopwatch();
    sw.Start();
    // Counter test StringBuilder    
    StringBuilder sb1 = new StringBuilder();
    const string Separator = " : ";
    for (int i = 0; i < 1000000; i++)
    {
        int SplitPosition = input.IndexOf(':');
        sb1.Append(input.Substring(0, SplitPosition).TrimEnd());
        sb1.Append(Separator);
        sb1.Append(input.Substring(SplitPosition + 1).TrimStart());
        sb1.Clear();
    }
    sw.Stop();
    //File write
    sw.Reset();
    sw.Start();
    // Selman Genç StringBuilder    
    StringBuilder sb2 = new StringBuilder();
    for (int i = 0; i < 1000000; i++)
    {
        char? previousChar = null;
        foreach (var ch in input)
        {
            if (ch == ' ' && previousChar == ch) { continue; }
            if (ch == ':' && previousChar != ' ') { sb2.Append(' '); }
            if (previousChar == ':' && ch != ' ') { sb2.Append(' '); }
            sb2.Append(ch);
            previousChar = ch;
        }
        sb2.Clear();
    }
    sw.Stop();
    //File write
    sw.Reset();
    sw.Start();
    for (int i = 0; i < 1000000; i++)
    {
        string output = string.Join(" : ", input.Split(':').Select(x => x.Trim()));
    }
    sw.Stop();
    /*(...)
    */
