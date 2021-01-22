    public class HtmlControl {}
    public class HtmlTextArea : HtmlControl { }
    
    // if you want to only allow HtmlTextArea, use HtmlTextArea 
    // here instead of HtmlControl
    public interface IExample<T> where T : HtmlControl
    {
        void Test(T ctrl);
    }
    
    public class Example : IExample<HtmlControl>
    {
        public void Test(HtmlControl ctrl) { Console.WriteLine(ctrl.GetType()); }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            IExample<HtmlControl> ex = new Example();
            ex.Test(new HtmlControl());    // writes: HtmlControl            
            ex.Test(new HtmlTextArea());   // writes: HtmlTextArea
            
        }
    }
