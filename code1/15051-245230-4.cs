    class FailsOnGarbageCollection  
    { ~FailsOnGarbageCollection() { throw new NotSupportedException(); } }
    class Program{
        static void WaitForever() { while (true) { var o = new object(); } }
        static void Main(string[] args)
        {
            var x = new FailsOnGarbageCollection();
            //x = null; //use this line to release x and cause the above exception
            WaitForever();
        }
    }
