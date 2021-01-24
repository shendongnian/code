    class Program
    {
        static void Main(string[] args)
        {
            del d = new del(add);
            d += sub;
    
            d.Invoke();
        }
    
        public static void add()
        {
            Console.WriteLine("add");
        }
    
        public static void sub()
        {
            Console.WriteLine("Sub");
        }
      } 
    }
