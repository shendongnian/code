    [Serializable()]
    public class Lst1
    {
        public string filed1 { get; set; }
        public int filed2 { get; set; }
        public bool filed100 { get; set; }
    }
    [Serializable()]
    public class Lst2 : Lst1
    {
        public string filed101 { get; set; }
    }
