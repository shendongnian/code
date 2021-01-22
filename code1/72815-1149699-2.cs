    class Program
    {
        static void Main(string[] args)
        {
            List<A> list = new List<A>();
            list.Add(new B());
    
            var list2 = list.ConvertAll<B>(a => B.FromA(a));
    
            Console.WriteLine(list2.First().myString);
            Console.ReadLine();
        }
    }
    
    class A
    {
        public string myString = "abc";
    }
    
    class B : A
    {
        public B() { }
    
        public static B FromA(A fromInstance)
        {
            B result = new B();
            result.myString = fromInstance.myString;
            return result;
        }
    }
