    public class Datum2
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool Administrator { get; set; }
    }
    
    public class Cursors
    {
        public string Before { get; set; }
        public string After { get; set; }
    }
    
    public class Paging
    {
        public Cursors cursors { get; set; }
        public string next { get; set; }
    }
    
    public class Summary
    {
        public int TotalCount { get; set; }
    }
    
    public class Members
    {
        public List<Datum2> Data { get; set; }
        public Paging Paging { get; set; }
        public Summary Summary { get; set; }
    }
    
    public class Datum
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Privacy { get; set; }
        public Members Members { get; set; }
    }
    
    public class RootObject
    {
        public List<Datum> Data { get; set; }
    }
