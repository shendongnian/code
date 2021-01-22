    public string[] Permute(char[] characters)
    {
        List<string> strings = new List<string>();
        for (int i = 0; i < characters.Length; i++)
        {
            for (int j = i + 1; j < characters.Length; j++)
            {
                strings.Add(new String(new char[] { characters[i], characters[j] }));
            }
        }
        return strings.ToArray();
    }
