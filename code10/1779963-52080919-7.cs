    [DebuggerTypeProxy(typeof(MyFormDebugView))]
    public class MyForm : Form
    {
        public int Foo { get; set; }
        public string Bar { get; set; }
    }
    public class MyFormDebugView
    {
        public int Foo { get; set; }
        public string Bar { get; set; }
    }
