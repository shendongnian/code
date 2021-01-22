    public class MyCommonControlBehaviors
    {
        public MyCommonControlBehaviors(ICommonBehaviorHost host) {}
        // ...
    }
    public class MyCustomControl : ICommonBehaviorHost
    {
        private MyCommonControlBehaviors common = null;
        public MyCustomControl() { common = new MyCommonControlBehaviors(this); }
        public Whatever Read() { return this.common.Read(); }
        public void Alert() { this.common.Alert(); }
    }
