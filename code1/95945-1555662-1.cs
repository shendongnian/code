    public class MyDeferredClass : IMyDeferredClass
    {
        public int MethodReturningInt(int parameter)
        {
            return 0;
        }
        public int IntegerProperty
        {
            get { return 0; }
            set {  }
        }
        public int this[int index]
        {
            get { return 0; }
        }
        public event EventHandler SomeEvent;
    }
