    public class MyClass
    {
      public static string var2 
      {
         get { return (string)System.Web.HttpContext.Current.Session["KEY_VAR2"]; }
         set { System.Web.HttpContext.Current.Session["KEY_VAR2"] = value; } 
      }
    }
