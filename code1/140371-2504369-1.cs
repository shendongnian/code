    public IEnumerator<string> ReturnSubstrings(string x)
    {
        if (x == null)
        {
             throw ArgumentNullException();
        }
        for (int i = 0; i < x.Length; i++)
        {
             yield return x.Substring(i);
        }
    }
    ...
    ReturnSubstring(null); // No exception thrown
