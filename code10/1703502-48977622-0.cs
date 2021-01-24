    public interface IClass
    {
        int a { get; set; }
        int b { get; set; }
    }
    class First : IClass
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c = 2;
        public _second;
    
        public First()
        {
            _second = new Second(this, c);
        }
    }
    
    
    class Second
    {
        public Second(IClass ic, int c)
        {
            if(c == 0)
            {
                ic.a = 1;
                ic.b = 2;
            }
            else
            {
                ic.a = -1;
                ic.b = -2;
            }
        }
    }
