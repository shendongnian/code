    public static int RemoveLinesFromFile(string path, string pattern)
    {
        List<string> lines = new List<string>(File.ReadAllLines(path));
        RegexHolder holder = new RegexHolder(pattern);
        int result = lines.RemoveAll(holder.DoesLineMatch);
        File.WriteAllLines(path, lines.ToArray());
        return result;
    }
