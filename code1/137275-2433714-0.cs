    public class Foo
    {
        public List<string> Strings { get; set; }
    }
    ...
    List<Foo> foos = new List<Foo>();
    foreach(string str in foos.SelectMany(f => f.Strings))
    {
        ...
    }
