    class ClientProxy : RealProxy
    {
        ... everything else ...
    
        public override object GetTransparentProxy() => innerProxy.GetTransparentProxy();
    }
