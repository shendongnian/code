       CallContext.LogicalSetData("Key", "My value");
       Console.WriteLine("{0} from {1}", CallContext.LogicalGetData("Key"),               
       AppDomain.CurrentDomain.FriendlyName);
    
       var appDomain = AppDomain.CreateDomain("Worker");
       appDomain.DoCallBack(() => Console.WriteLine("{0} from {1}", 
           CallContext.LogicalGetData("Key"), 
           AppDomain.CurrentDomain.FriendlyName));
       AppDomain.Unload(appDomain);
                        
       CallContext.FreeNamedDataSlot("Key");
