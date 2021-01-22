    public delegate void MyEvent(object sender);
    
    interface ITest
    {
        event MyEvent Clicked;
    }
    
    class Test : Itest
    {
        private MyEvent clicked;
    
        event MyEvent Itest.Clicked
        {
            add
            {
                clicked += value;
            }
            remove
            {
                clicked -= value;
            }
        }
    
        public static void Main() { }
    }
