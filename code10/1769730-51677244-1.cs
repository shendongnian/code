    public class CompanyA
    {
        public Adult Adult { get; set; }
        public Infant Infant { get; set; }
    }
    public class CompanyB
    {
        public Adult Adult { get; set; }
        public Infant Infant { get; set; }
    }
    
    public class Adult 
    {
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
    }
    
    public class Infant
    {
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
    }
