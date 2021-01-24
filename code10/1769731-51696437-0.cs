    public class Ages 
    {
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
    }
    
    public class CompanyA
    {
        public Ages Adult = new Ages { MinAge = 14, MaxAge = 55 };
        public Ages Infant = new Ages { MinAge = 0, MaxAge = 4 };
    }
    
    public class CompanyB
    {
        public Ages Adult = new Ages { MinAge = 18, MaxAge = 60 };
        public Ages Infant = new Ages { MinAge = 0, MaxAge = 2 };
    }
