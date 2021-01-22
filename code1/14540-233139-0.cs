    Dictionary<NameValuePair,int> hs = new Dictionary<NameValuePair,int>();
    foreach (i in jaggedArray)
    {
        foreach (j in i)
        {
            if (!hs.ContainsKey(j))
            {
                hs.Add(j, 0);
            }
        }
    }
    IEnumerable<NameValuePair> unique = hs.Keys;
