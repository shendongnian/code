    public string[] GetValues()
    {
        string[] values;
        using(StreamReader sr = new StreamReader(Path.Combine(foldr, file))
        {
            string text = sr.ReadToEnd();
            values = text.Split(',');
        }
        return values;
    }
