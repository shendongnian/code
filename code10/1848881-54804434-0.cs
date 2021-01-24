    public static IEnumerable<(string, string, string)> ReadCsvLines()
    {
        using (var reader = new StreamReader(@"CSV_testdaten.csv"))
        {
            while (!reader.EndOfStream)
            {
                string newLine;
                while ((newLine = reader.ReadLine()) != null)
                {
                    var values = newLine.Split(',');
                    yield return (values[0], values[1], values[2]);
                }
            }
        }
    }
    
