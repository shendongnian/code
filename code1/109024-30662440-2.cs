    class Test
    {
        static void Main(string[] args)
        {
            A a = new C(); // OK
            IList<A> listOfA = new List<C>().CastList<C,A>(); // now ok!
        }
    }
