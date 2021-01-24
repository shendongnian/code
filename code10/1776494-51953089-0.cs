    interface IExample
    {
        void Method1();
    }
    interface IExample2 : IExample
    {
        void Method2();
    }
    class Screen : IExample2
    {
        public void Method2()
        {
        }
        public void Method1()
        {
        }
    }
