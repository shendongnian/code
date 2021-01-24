    public class Answerbyday
    {
        public string day { get; set; }
        public int total { get; set; }
        public string tme { get; set; }
        public string tma { get; set; }
    }
    public class Byday
    {
        public List<Answerbyday> answerbyday { get; set; }
    }
    public class Condo
    {
        public string condo { get; set; }
        public string name { get; set; }
        public int total { get; set; }
        public int answered { get; set; }
        public string tma { get; set; }
        public string tme { get; set; }
    }
    public class GroupbyDay // RootObject
    {
        public int answered { get; set; }
        public int total { get; set; }
        public string tma { get; set; }
        public string tme { get; set; }
        public int total_condos { get; set; }
        public Byday byday { get; set; }
        public List<Condo> condos { get; set; }
    }
