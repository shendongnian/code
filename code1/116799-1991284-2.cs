    string[] lines = File.ReadAllLines(filename);
    int startLine = lines.IndexOf(startMarker);
    int endLine = lines.IndexOf(endMarker);
    if (startLine == -1 || endLine == -1)
    {
        // throw some sort of exception - the markers aren't present
    }
    string[] section = new string[endLine - startLine - 1];
    Array.Copy(lines, startLine + 1, section, 0, section.Length);
    richTextBox.Rtf = string.Join("\r\n", section);
