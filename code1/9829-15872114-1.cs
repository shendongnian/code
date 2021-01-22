    class Class1
    {
        public void genmethod<T>(T i,int Count)
        {
            List<string> list = i as List<string>;
            for (int j = 0; j < Count; j++)
            {
                Console.WriteLine(list[j]);
            }
        }
        static void Main(string[] args)
        {
            Class1 c = new Class1();
            c.genmethod<string>("str",0);
            List<string> l = new List<string>();
            l.Add("a");
            l.Add("b");
            l.Add("c");
            l.Add("d");
            c.genmethod<List<string>>(l,l.Count);
            Console.WriteLine("abc");
            Console.ReadLine();
        }
    }
