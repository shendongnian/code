        class Program
        {
            static void Main(string[] args)
            {
                object o = new object();
        
                Console.WriteLine(IsExistingObject(o));
                Console.WriteLine(IsExistingObject(new object()));
    
                o.ToString();  // Just something to simulate further usage of o.  If we didn't do this, in a release build, o would be collected by the GC.Collect call in IsExistingObject. (not in a Debug build)
            }
        
            public static bool IsExistingObject(object o)
            {
                var oRef = new WeakReference(o);
        			
    #if DEBUG 
                o = null; // In Debug, we need to set o to null.  This is not necessary in a release build.
    #endif
    
                GC.Collect();
                GC.WaitForPendingFinalizers();
        
                return oRef.IsAlive;
            }
        }
