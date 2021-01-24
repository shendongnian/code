    public class File
    {
        public string Filename { get; set; }
        public string Supplier { get; set; }
        // ...
        public List<Good> Goods { get; set; }
        public List<Error> Errors { get; set; }
    }
    public class Good
    {
        public string Name { get; set; }
        public string Designator { get; set; }
        public string Pin { get; set; }
        // ...
    }
    public class Error
    {
        public string Name { get; set; }
        public string Designator { get; set; }
        // ...
    }
