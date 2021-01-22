    public class MyClass
    {
        private readonly IWebSiteConfiguration _config = null;
    
        // just so you don't break any other code, you can default
        // to your static singleton on a default ctor
        public MyClass () : this (new WebSiteConfiguration.Instance) { }
    
        // new constructor permits you to swap in any implementation
        // including your mock!
        public MyClass (IWebSiteConfiguration config) 
        {
            _config = config;
        }
    
        public void DoSomething ()
        {
            // huzzah!
            code = _config.getCodeByCodeNameAndType ("some.string", someCatalog)
        }
    }
