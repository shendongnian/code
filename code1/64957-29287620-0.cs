    public struct MyBool
    {
        private bool _invertedValue;
    
        public MyBool(bool b) 
        {   
            _invertedValue = !b;
        }
    
        public static implicit operator MyBool(bool b)
        {
            return new MyBool(b);
        }
    
        public static implicit operator bool(MyBool mb)
        {
            return !mb._invertedValue;
        }
    
    }
    static void Main(string[] args)
    {
            MyBool mb = false; // should expose false.
            Console.Out.WriteLine("false init gives false: " 
                                  + !mb);
            MyBool[] fakeBoolArray = new MyBool[100];
            Console.Out.WriteLine("Default array elems are true: " 
                                  + fakeBoolArray.All(b => b) );
            fakeBoolArray[21] = false;
            Console.Out.WriteLine("Assigning false worked: " 
                                  + !fakeBoolArray[21]);
            fakeBoolArray[21] = true;
            // Should define ToString() on a MyBool,
            // hence the !! to force bool
            Console.Out.WriteLine("Assigning true again worked: " 
                                  + !!fakeBoolArray[21]);
    }
