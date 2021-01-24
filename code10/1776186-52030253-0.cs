    public class B
    {
        void MyMethod()
        {
            var instanceA = new A();
            var someRefType = new RefType();
            someRefType.DoSomething();
            someRefType.DoSomethingLater(a => instanceA.ModifyRefType(someRefType));
        }
    }
    public class A
    {
        private Action<object> _action;
        public void ModifyRefType(Action<object> action)
        {
            this._action = action;
        }
        public void DoModify(object configuration)
        {
            this._action?.Invoke(configuration);
        }
    }
