    interface IExample<T> where T : HtmlControl
    {
        void Test (T ctrl) ;
    }
    
    public class Example : IExample<HtmlTextArea>
    {
        public void Test (HtmlTextArea ctrl) 
        { 
        }
    }
