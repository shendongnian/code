    class First
    {
        public int a {get;set;}
        public int b {get;set;}
        public int c {get;set;} = 2;
        public Second _second {get;set;}
    
        public First()
        {
            _second = new Second(this);
        }
    }
