    public class foo
    {
        public List<String> S1 { get; set; }
        private List<string> s = new List<string>();
        public List<String> S2
        {
            get { return s;}
            set { s = value; }
        }
    }
    foo f = new foo();
    f.S1.Add("thing");
    f.S2.Add("thing");
