       class Program
        {
            static void Main(string[] args)
            {
                var a = new object();
                var b = new object();
                Console.WriteLine("", a.GetId(), b.GetId());
            }
        }
    
        public static class MyExtensions
        {
            //this dictionary should use weak key references
            static Dictionary<object, int> d = new Dictionary<object,int>();
            static int gid = 0;
           
            public static int GetId(this object o)
            {
                if (d.ContainsKey(o)) return d[o];
                return d[o] = gid++;
            }
        }   
