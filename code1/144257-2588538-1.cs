    interface IExample<T>
    {
        void Test (T ctrl) where T : HtmlControl;
    }
    
    class Example<HtmlTextArea> : IExample<T>
    {
        public void Test (HtmlTextArea ctrl) 
        { 
        }
    }
