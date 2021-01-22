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
