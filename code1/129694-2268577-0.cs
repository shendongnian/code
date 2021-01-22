    public delegate void MyEvent(object sender);
    
    interface ITest
    {
        event MyEvent Clicked;
    }
    
    class Test : Itest
    {
        event MyEvent ITest.Clicked;  // CS0071
        public static void Main() { }
    }
