    using en.my.services; // Make Service namespace known
    namespace en.my.clients 
    {
        public class MyServiceClient
        {
            VariableService svc = null;
    
            public MyServiceClient ( VariableService varsserv ) // <- Parameter-Injection via 
                                                                // your DI Framework
            {   
                svc = varserv;
            }
            public void SomeMethod()
            {
                svc.SomeVariable = "Update";
            }
        }
    }
