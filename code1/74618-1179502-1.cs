    public class MyBase
    {
        protected virtual void DoCommand() { throw new NotImplementedException(); }
    
        public void Func()
        {
            ...
            DoCommand();
            ...
        }
    }
    public class MySubClass : MyBase
    {
        protected override void DoCommand()
        {
            ...
        }
    }
