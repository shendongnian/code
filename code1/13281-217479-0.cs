    public static IEnumerable<string> ReadLinesFromFile(string filename)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            while (true)
            {
                string s = reader.ReadLine();
                if (s == null)
                    break;
                yield return s;
            }
        }
    }
