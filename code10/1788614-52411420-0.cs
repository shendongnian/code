    string[] lines = new string[publisherList.Count];
    for (int i = 0; i < publisherList.Count; i++)
    {
        lines[i] = String.Format("{0}", publisherList[i].);
    }
    File.WriteAllLines(@"Publishers.csv", lines);
