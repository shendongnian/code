    class ClientProxy : RealProxy
    {
        ... everything else ...
    
        public override object GetTransparentProxy() => innerProxy.GetTransparentProxy();
        public object GetOuterTransparentProxy() => base.GetTransparentProxy();
    }
    ...
    var clientDataProxy = new ClientProxy(typeof(IData), dataImpl);
    var clientDataImpl = clientDataProxy.GetOuterTransparentProxy() as IData;
    
    var clientLogicProxy = new ClientProxy(typeof(ILogic), logicImpl);
    var clientLogicImpl = clientLogicProxy.GetOuterTransparentProxy() as ILogic;
    ...
