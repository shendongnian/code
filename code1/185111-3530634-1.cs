    public static IEnumerable<string> Lines(this string data)
    {
        using (var sr = new StringReader(data))
        {
            string line;
    
            while ((line = sr.ReadLine()) != null)
                yield return line;
        }
    }
