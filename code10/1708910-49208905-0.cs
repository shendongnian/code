    interface IPrint
    {
        void Print();
    }
    class A : IPrint
    {
        public void Print()
        {
        }
    }
    class B : IPrint
    {
        public void Print()
        {
        }
    }
    ...
    foreach (IPrint p in printables)
    {
        p.Print();
    }
