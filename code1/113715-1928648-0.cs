    class Program
    {
        static void Main(string[] args)
        {
            object o = new object();
    
            Console.WriteLine(IsExistingObject(o));
            Console.WriteLine(IsExistingObject(new object()));
        }
    
        public static bool IsExistingObject(object o)
        {
            var oRef = new WeakReference(o);
    			
            o = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
    
            return oRef.IsAlive;
        }
    }
