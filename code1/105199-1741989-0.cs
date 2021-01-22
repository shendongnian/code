    public class Range
    {
        public readonly Int32 From;
        public readonly Int32 To;
        public Range(Int32 from, Int32 to)
        {
            From = from;
            To = to;
        }
    }
    public static class RangeSplitter
    {
        public static Range[] Split(String s)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            String[] parts = new Regex(@"(?<!\+)\+(?!\+)").Split(s);
            List<Range> result = new List<Range>();
            var patterns = new Dictionary<Regex, Action<Int32[]>>();
            patterns.Add(new Regex(@"^(?<v>\d+)$"),
                values => result.Add(new Range(values[0], values[0])));
            patterns.Add(new Regex(@"^(?<v>\d+)\+\+$"),
                values => result.Add(new Range(values[0], Int32.MaxValue)));
            patterns.Add(new Regex(@"^\+\+(?<v>\d+)$"),
                values => result.Add(new Range(Int32.MinValue, values[0])));
            patterns.Add(new Regex(@"^(?<v1>\d+)\+\+(?<v2>\d+)$"),
                values => result.Add(new Range(values[0], values[1])));
            foreach (String part in parts)
            {
                foreach (var kvp in patterns)
                {
                    Match ma = kvp.Key.Match(part);
                    if (ma.Success)
                    {
                        Int32[] values = ma.Groups
                            .OfType<Group>()
                            .Skip(1) // group 0 is the entire match
                            .Select(g => Int32.Parse(g.Value))
                            .ToArray();
                        kvp.Value(values);
                    }
                }
            }
            return result.ToArray();
        }
    }
