    public class ClientProgram {
            public static void Main( string[] args ) {
                ITest test = (ITest)Activator.GetObject( typeof( ITest ), "http://127.0.0.1:8765/Test.rem" );
                ITest test2 = (ITest)new MyProxy( test ).GetTransparentProxy();
                test2.Foo();
            }
        }
    public class MyProxy : RealProxy {
        private object _obj;
        public MyProxy( object pObj )
            : base( typeof( ITest ) ) {
            _obj = pObj;
        }
        public override IMessage Invoke( IMessage msg ) {
            RealProxy rp = RemotingServices.GetRealProxy( _obj );
            return rp.Invoke( msg );
        }
    }
