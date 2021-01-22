    var constituents = new Pool().Constituents.Select((c, i) =>
        new
        {
            Constituent = c,
            Index = i
        });
    var items = from c in constituents
                where !string.IsNullOrEmpty(c.Constituent.Name)
                      && string.IsNullOrEmpty(c.Constituent.Curve)
                let curves = new[]{
                                "EUR" + c.Index.ToString(),
                                "USD" + c.Index.ToString()
                                   }
                let match = new ConstituentMatch(){
                    new Group("High") {
                        new Entry(
                                    c.Constituent.Name + " Ltd.",
                                    curves),
                        new Entry(
                                    c.Constituent.Name + " Inc.",
                                    curves)
                    }
                }
                select new
                {
                    Name = c.Constituent.Name,
                    Curves = curves,
                    Match = match
                };
...
    public class Constituent
    {
        public string Name { get; set; }
        public string Curve { get; set; }
    }
    public class Pool
    {
        public List<Constituent> Constituents { get; set; }
    }
    public class Entry
    {
        public Entry(string entry, IEnumerable<string> curves)
        {
        }
    }
    public class Group : List<Entry>
    {
        public Group(string group) { }
    }
    public class ConstituentMatch : List<Group>
    {
    }
