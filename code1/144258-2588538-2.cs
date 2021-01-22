    interface IExample<T> where T : HtmlControl
    {
        void Test (T ctrl) ;
    }
    
    class Example<HtmlTextArea> : IExample<T>
    {
        public void Test (HtmlTextArea ctrl) 
        { 
        }
    }
