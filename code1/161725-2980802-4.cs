    public interface IDoSomething
    {
        void A();
        void B();
    }
    public class ToLogClass : IDoSomething
    {
        public void A() { ... }
        public void B() { ... }
    }
    public class LoggedClass : IDoSomething
    {
        private IDoSomething Inner { get; set; }
        private Logger Logger { get; set; }
        public Proxy( IDoSomething inner, Logger logger )
        {
            this.Inner = inner;
            this.Logger = logger;
        }
        public void A()
        {
            this.Logger.Info( "A callsed on {0}", this.Inner.GetType().Name );
            this.Inner.A();
        }
    }
