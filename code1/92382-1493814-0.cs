    public abstract class ClientRequestInfo
    {
        public abstract void NonGenericMethod();
    }
    
    public class ClientRequestInfo<K, V> : ClientRequestInfo
    {
        public override void NonGenericMethod()
        {
            // generic-specific implementation
        }
    }
