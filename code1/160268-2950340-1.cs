    public class MyForm : Form
    {
        public void DoSomething()
        {
            // Implementation
        }
    }
    
    public class OtherClass
    {
        public void DoSomethingElse(MyForm form)
        {
            form.DoSomething();
        }
    }
