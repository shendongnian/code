    class Program
    {
        static void Main(string[] args)
        {
            List<Base> l = new List<Base>();
    
            l.Add(new StrBase {Prop = "foo"});
            l.Add(new IntBase {Prop = 42});
    
            Console.WriteLine("Using each item");
            foreach (var o in l)
            {
                o.Use();
            }
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
