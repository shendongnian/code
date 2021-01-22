    public interface IOperations
    {
        void DoStuff();
        void Foo();
    }
    public class A : IOperations
    {
        public void Init()
        {
            // Do class A init stuff
        }
        #region IOperations Members
        public void DoStuff()
        {
            // ...
        }
        public void Foo()
        {
            // ...
        }
        #endregion
    }
    public class B : IOperations
    {
        A _operations = new A();
        public void Init(int initData)
        {
            _operations.Init();
            // Do class B init stuff
        }
        #region IOperations Members
        public void DoStuff()
        {
            _operations.DoStuff();
        }
        public void Foo()
        {
            _operations.Foo();
        }
        #endregion
    }
