    public IEnumerator<string> ReturnSubstrings(string x)
    {
        if (x == null)
        {
             throw ArgumentNullException();
        }
        return ReturnSubstringsImpl(x);
    }
    private IEnumerator<string> ReturnSubstringsImpl(string x)
    {
        for (int i = 0; i < x.Length; i++)
        {
             yield return x.Substring(i);
        }
    }
