    public class MyPane : WindowPane
    {
        public static void Test(WindowPane p)
        {
             var service = p.GetService(typeof(Service));
             // etc.
        }
    }
