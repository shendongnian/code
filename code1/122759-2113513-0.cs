    static string FixString(string line)
    {
        if (line == null)
            return string.Empty;
        int firstBarPosition = line.IndexOf('|');
        if (firstBarPosition == -1 || firstBarPosition + 1 == line.Length)
            return line;
        StringBuilder sb = new StringBuilder(line);
        sb.Replace('|', '\\', firstBarPosition + 1, line.Length - (firstBarPosition + 1));
        return sb.ToString();
    }
