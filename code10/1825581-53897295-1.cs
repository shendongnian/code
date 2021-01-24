    interface IFace
    {
        void Method1();
    }
    class Class1 : IFace
    {
        void IFace.Method1()
        {
            Console.WriteLine("I am calling you from Class1");
        }
    }
    class Class2 : Class1
    {
        public void Method1()
        {
            Console.WriteLine("i am calling you from Class2");
        }
    }
    int main void ()
    {
        IFace ins = new Class2();
        ins.Method1();
    }
