    public class HttpRuntimeWrapper
    {
         virtual string AppDomainAppVirtualPath 
         { 
                get
                { 
                       return HttpRuntime.AppDomainAppVirtualPath; 
                }
         }
    }
