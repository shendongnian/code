    private IEnumerable<string> GetOddLines(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        IEnumerator allLines = lines.GetEnumerator();
        while (allLines.MoveNext())
        {
            yield return (string)allLines.Current;
            if (!allLines.MoveNext())
            {
                break;
            }
        }
    }
