    class MyGenericClass<A>
    {
        public void Example()
        {
            List<A> list = new List<A>(); // List<T>'s generic parameter T was set to whatever A is
            list.Add(default(A)); // default(A) is some default value of type A
        }
    }
