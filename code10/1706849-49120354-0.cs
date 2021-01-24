    public class Outer
    {
        public Outer()
        {
            MyField = new MyField();
        }
        public Inner MyField {get; private set;}
    }
    
    public class Inner
    {        
        internal Inner()
        {
        }
        public string Message = "Hello";
    }
