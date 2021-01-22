    public class MyBase
    {
        protected virtual DoCommand() { throw new NotImplementedException(); }
    
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
