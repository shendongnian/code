    using System;
    ...
    using System.Web.Script.Services
    
    namespace MyGreatCompany.ScriptServices 
    {
        public class MyScriptHandlerFactory /* implement all the interfaces */
        {
            private ScriptHandlerFactory internalFactory;
            public MyScriptHandlerFactory()
            {
                internalFactory = new ScriptHandlerFactory();
            }
            ...
        }
    }
