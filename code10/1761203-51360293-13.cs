    public class Place
    {
        public string native { get; set; }
        public string school { get; set; }
        public string college { get; set; }
    }
    
    public class Mark
    {
        public string tenthmark { get; set; }
        public string twelthmark { get; set; }
        public string Diploma { get; set; }
        public string DiplomaPG { get; set; }
        public string Ug { get; set; }
        public string PG { get; set; }
    }
    
    public class RootObject
    {
        public string name { get; set; }
        public Place place { get; set; }
        public string dob { get; set; }
        public List<int> ids { get; set; }
        public List<Mark> mark { get; set; }
    }
