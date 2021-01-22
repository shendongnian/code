    public class Class1
    {
        public IEnumerable<Name> Names { get; set; }
        public IEnumerable<Name> GetNamesList()
        {
            List<Name> list = new List<Name>();
            list.Add(new Name("Al", "Alverson"));
            list.Add(new Name("Bill", "Billerson"));
            return list;
        }
    }
