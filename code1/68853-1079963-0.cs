    class MyInt
    {
        public int Val { get; set; }
        public MyInt(int val) { this.Val = val; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MyInt[] array = new MyInt[] { new MyInt(1), new MyInt(2) };
    
            foreach (var obj in array) Console.Write("{0}\t", obj.Val);
    
            foreach (var obj in array)
            { 
                obj = new MyInt(100); // This doesn't compile! the reference is read only
                obj.Val *= 10; // This works just fine!
            }
    
            foreach (var obj in array) Console.Write("{0}\t", obj.Val);
        }
    }
