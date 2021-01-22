    public class RangeParser
    {
        public static IEnumerable<Int32> Parse(String s, Int32 firstPage, Int32 lastPage)
        {
            String[] parts = s.Split(' ', ';', ',');
            Regex reRange = new Regex(@"^\s*((?<from>\d+)|(?<from>\d+)(?<sep>(-|\.\.))(?<to>\d+)|(?<sep>(-|\.\.))(?<to>\d+)|(?<from>\d+)(?<sep>(-|\.\.)))\s*$");
            foreach (String part in parts)
            {
                Match maRange = reRange.Match(part);
                if (maRange.Success)
                {
                    Group gFrom = maRange.Groups["from"];
                    Group gTo = maRange.Groups["to"];
                    Group gSep = maRange.Groups["sep"];
                    if (gSep.Success)
                    {
                        Int32 from = firstPage;
                        Int32 to = lastPage;
                        if (gFrom.Success)
                            from = Int32.Parse(gFrom.Value);
                        if (gTo.Success)
                            to = Int32.Parse(gTo.Value);
                        for (Int32 page = from; page <= to; page++)
                            yield return page;
                    }
                    else
                        yield return Int32.Parse(gFrom.Value);
                }
            }
        }
    }
