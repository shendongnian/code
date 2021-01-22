    // Adds text to the beginning of the log RTB
    // Also keeps the log RTB trimmed to 100 lines
    int size = Math.Min(rtbLog.Lines.Length + 1, 100);
    string[] lines = new string[size];
    lines[0] = "text";
    Array.Copy(rtbLog.Lines, 0, lines, 1, size - 1);
    rtbLog.Lines = lines;
