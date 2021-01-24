    public class Project
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        private List<string> _comments = new List<string>();
        public List<string> Comments 
        { 
            get
            {
                return _comments;
            }
            set
            {
                if (value != _comments)
                {
                    if (value == null)
                        _comments = new List<string>();
                    else
                        _comments = value;
                }
            } 
        }
        public Project () { }
        // Other methods
    }
