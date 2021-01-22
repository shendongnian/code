    public class MyState
    {
        public bool Method1HasExecuted { get; set; }
        public bool Method2HasExecuted { get; set; }
        public bool Method3HasExecuted { get; set; }
    }
    public class MyClass
    {
        public MyState MyClassState { get; set; }
        
        public void Method1() { MyClassState.Method1HasExecuted = true; }
        public void Method2() { MyClassState.Method2HasExecuted = true; }
        public void Method3() { MyClassState.Method3HasExecuted = true; }
        public bool Modify()
        {
            return MyClassState.Method1HasExecuted && MyClassState.Method2HasExecuted && MyClassState.Method3HasExecuted ? Spa.ClientModify() : false;
        }
    }
