    class Program
    {
        static void Main(string[] args)
        {
            object o = new object();
    
            Console.WriteLine(IsExistingObject(o));
            Console.WriteLine(IsExistingObject(new object()));
            Console.WriteLine(o.ToString());  // This keeps o alive.  If we didn't do this, IsExistingObject would consider o a new object, because it would be collected.
        }
    
        public static bool IsExistingObject(object o)
        {
            var oRef = new WeakReference(o);
    			
            GC.Collect();
            GC.WaitForPendingFinalizers();
    
            return oRef.IsAlive;
        }
    }
