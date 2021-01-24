    public class MyClass
    {
       private string CookieName { get; }
       
       public MyClass()
       {
          CookieName = "TempData" + DateTime.Now.Ticks.ToString();
       }
    }
