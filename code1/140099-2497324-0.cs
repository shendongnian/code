    public void DoWhatYouAreAskingFor(StreamReader sr, List<string> list)
    {
        string line = sr.ReadLine();
        if (!list.Contains(line))
        {
            list.Add(line);
        }
    }
