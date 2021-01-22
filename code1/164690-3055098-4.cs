    public interface ICommonBehaviorHost
    {
        void Notify();
    }
    public class MyCommonControlBehaviors
    {
        ICommonBehaviorHost hst = null;
        public MyCommonControlBehaviors(ICommonBehaviorHost host) 
        {
            this.hst = host;
        }
        public void Alert() { this.hst.Notify(); }  // Calls back into the hosting control
        // ...
    }
    public class MyCustomControl : ICommonBehaviorHost
    {
        private MyCommonControlBehaviors common = null;
        public MyCustomControl() { common = new MyCommonControlBehaviors(this); }
        public Whatever Read() { return this.common.Read(); }
        public void Alert() { this.common.Alert(); }
        void ICommonBehaviorHost.Notify() { /* called by this.common */ }
    }
