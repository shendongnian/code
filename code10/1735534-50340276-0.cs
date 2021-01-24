    static void Main(string[] args)
    {
        List<string> strings = new List<string>
        {
            "apple",
            "banana",
            "Papa's citrus"
        };
        var lastNdx = strings.Count - 1;
        var sentence = "I have " + String.Join(", ", 
            strings.Select((s, ndx) =>
            {
                var ls = s.ToLower();
                string ret = "";
                if ("aeiou".Contains(ls[0]))
                    ret = "an " + s;
                else if (ls.Contains("\'"))
                    ret = s;
                else ret = "a " + s;
                if (ndx == lastNdx)
                    ret = "and " + ret;
                return ret;
            }).ToArray() );
        Console.WriteLine(sentence);
    }
