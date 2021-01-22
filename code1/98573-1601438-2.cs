    public class MyClass
    {
        public MyClass () { }
    
        public void DoSomething ()
        {
            // bad singleton! bad boy! static references are bad! you
            // can't change them! convenient but bad!
            code = WebSiteConfiguration.Instance.getCodeByCodeNameAndType (
                "some.string", 
                someCatalog)
        }
    }
