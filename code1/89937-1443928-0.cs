    class Program
    {
        static void Main(string[] args)
        {
            b obj = new b();
            obj.item1 = 4;// should show an error but it doent ???
        }
    }
    
    class a
    {
        public virtual int item1 {get; set;}
        public virtual int item2 { get; set; }
    
    }
    
    class b : a
    {
        public override int item1
        { 
             get { return base.item1; }
             set { }
        }
    }
    
        class c : a
    {
    
    }
