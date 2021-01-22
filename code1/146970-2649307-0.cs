    string FillString(string text, int count)
    {
        StringBuilder s = new StringBuilder();
        for(int i = 0; i <= count / text.Length; i++)
            s.Add(text);
        return(s.ToString().Substring(count));
    }
