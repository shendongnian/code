    public class MyLMXProxyServerWrapper : ILMXProxyServer {
        // LMXProxyServerClass is the library in which need a lot of installation 
        private readonly LMXProxyServerClass lmxProxyServer; 
        
        public void DoSOmething(Something xxxxxxx){
             lmxProxyServer.DoSOmething(xxxxxxxx);
        }
        
        //...code omitted for brevity
    }
    
