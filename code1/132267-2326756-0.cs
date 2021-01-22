    public static void ForceSpaceGroupsToBeTabs(this List<string> lines)
    {
        string spaceGroup = new String('.', 4);
        for (int i = 0; i < lines.Count; i++)
        {
            lines[i] = lines[i].Replace(spaceGroup("T"));
        }
    }
