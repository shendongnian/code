    class Program
    {
        static void Main(string[] args)
        {
            List<B> list = new List<B>();
            list.Add(new B());
    
            var list2 =
                from p in list
                select p as A;
    
            Console.WriteLine(list2.First().myString);
            Console.ReadLine();
        }
    }
    
    class A
    {
        public string myString = "abc";
    }
    class B : A { }
