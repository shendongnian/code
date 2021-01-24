    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Ing
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Relation
    {
        public int DId { get; set; }
        public int IId { get; set; }
    }
