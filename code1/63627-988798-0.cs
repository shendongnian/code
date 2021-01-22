    public delegate void MyDelegate();
    
    public class MyClass
    {
        public event MyDelegate Myevent;
    
        public void DoSomething()
        {
            this.Myevent();
        }
    }
    public static class Class
    {
        public static void RunProcess()
        {
            txtData.Text += "Message";
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MyClass myClass = new MyClass();
            myClass.Myevent += Class.RunProcess;
        }
    }
