    int count = 0, n = 0;
    
    if(substring != "")
    {
        while ((n = source.IndexOf(substring, n, StringComparison.InvariantCulture)) != -1)
        {
            n += substring.Length;
            ++count;
        }
    }
