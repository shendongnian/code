    static void Main(string[] args)
    {
        System.IO.StreamReader sr = // ...
        var filtered = Enumerable.Where(
            StreamReaderToSeq(sr), input => { int temp; return int.TryParse(x, out temp); });
    }
    static IEnumerable<string> StreamReaderToSeq(System.IO.StreamReader sr)
    {
        while(!sr.EndOfStream)
        {
            yield return sr.ReadLine();
        }
    }
