    public class HddInfoList : List<Tuple<string, string>>
    {
        public HddInfoList(IEnumerable<Tuple<string, string>> collection) : base(collection)
        {
        }
        public override string ToString()
        {
            //For example return first items of tuple separated by '-'
            return string.Join("-", this.Select(m => m.Item1));
        }
    }
