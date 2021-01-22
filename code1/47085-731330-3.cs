    class Blur
    {
        private static int count = 0;
        
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    
        public Blur()
        {
            _name = "Blur" + count++.ToString();
        }
    }
