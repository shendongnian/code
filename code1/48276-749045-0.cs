    class MyBase 
    {
        public virtual void MyVirtual() { }
    }
    class MyGenericDerived<T> : T
    {
        public override void MyVirtual() 
        {
            Console.WriteLine("Overridden!"); 
        }
    } 
    MyBase obj = new MyGenericDerived<MyBase>();
    obj.MyVirtual();
