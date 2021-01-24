    public class First
    {
        public int x { get; set; }
        public Second second;
        public First()
        {
            x = 0;
            second = new Second(this);
        }    
        public void run()
        {
            second.change();
        }
    }
    public class Second
    {
        private First _first;
        public Second(First first)
        {
            _first = first;
        }
        public void change()
        {
            _first.x = 2;
        }
    }
