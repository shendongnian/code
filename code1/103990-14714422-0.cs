    public static class SessionExtensions {
      public static T Get<T>(this HttpSessionBase session, string key)  {
         var result;
         if (session.TryGetValue(key, out result))
         {
            return (T)result;
         }
         // or throw an exception, whatever you want.
         return default(T);
       }
     }
    public class HomeController : Controller {
        public ActionResult Index() {
           //....
           var candy = Session.Get<Candy>("chocolate");
           return View(); 
        }
    }
