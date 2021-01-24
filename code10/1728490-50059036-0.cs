    public class A() {
        [Log]
        public void MethodA() {
            CallContext.SetLogicalData( "log-id", Guid.New().ToString() )
            var b = new B();
            b.MethodB();
        }
    }
    public class B() {
        [Log]
        public void MethodB () {
        // some action B
        }
    }
    //...
    public void Log( string message )
    {
        _backEnd.Write( $"[Id: {CallContext.GetLogicalData( "log-id" )}] {message}" );
    }
