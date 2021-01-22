    public interface IUrlHelperExtensions 
    {
        string GetReturnUrl(UrlHelper helper);
    }
    
    public static class UrlHelperExtensions
    {
        public static IUrlHelperExtensions Extensions(this UrlHelper target)
        {
            return UrlHelperExtensionFactory(target);
        }
    
        static UrlExtensions 
        {
            UrlHelperExtensionFactory = () => new DefaultUrlHelperExtensionStrategy();
        }
    
        public static Func UrlHelperExtensionFactory { get; set; }
    }   
    
    public DefaultUrlHelperExtensionStrategy : IUrlHelperExtensions 
    {
        public string GetReturnUrl(UrlHelper helper) 
        {
            return // your implementation of GetReturnUrl here
        }
    }
