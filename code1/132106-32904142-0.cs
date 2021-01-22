    public class SuperBase
    {
        public string Speak() { return "Blah in SuperBase"; }
    }
    public class Base : SuperBase
    {
        public new string Speak() { return "Blah in Base"; }
    }
    public class Child : Base
    {
        public new string Speak() { return "Blah in Child"; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Child childObj = new Child();
            Console.WriteLine(childObj.Speak());
            Console.WriteLine((childObj as Base).Speak()); // casting the child to parent first and then calling Speak()
            Console.WriteLine((childObj as SuperBase).Speak());
                                 
        }
    }
