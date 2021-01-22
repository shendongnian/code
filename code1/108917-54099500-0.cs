    IEnumerable<string> GetNextString(string input)
    {
        using (var sr = new StringReader(input))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                yield return s;
            }
        }
    }
