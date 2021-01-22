    public class ClassHelper()
    {
       public static ClassHelper GetInstance()
        {
            ClassHelper instance = null;
    
            if (System.Web.HttpContext.Current == null)
            {
                instance = new ClassHelper();
                return instance;
            }
    
            if (System.Web.HttpContext.Current.Application["CLASSHELPER_INSTANCE"] == null)
            {
                instance = new ClassHelper();
                System.Web.HttpContext.Current.Application["CLASSHELPER_INSTANCE"] = instance;
            }
    
            instance = (ClassHelper)System.Web.HttpContext.Current.Application["CLASSHELPER_INSTANCE"];
    
            return instance;
        }
    
    
       public string Test()
       {
           return "test123";
       }
    
    }
