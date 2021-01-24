    using System;
    using System.Diagnostics;
    
    public class C {
        public Object _obj = new object();
        public void M() 
        {
            Alpha("This goes away in Release");
            Alpha(_obj.GetHashCode() + "...this is ommited");
        }
    
        [Conditional("DEBUG")]
        public static void Alpha(String s)
        {
            Console.WriteLine(s);
        }
    }
