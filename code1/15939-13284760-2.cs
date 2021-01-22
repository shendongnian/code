    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pd[0]();
            pd[1]();
        }
        public delegate void delegates();
        static delegates[] pd = new delegates[] 
                                { 
                                   new delegates(MyClass.p1), 
                                   new delegates(MyClass.p2) 
                                };
        public static class MyClass
        {
            public static void p1()
            {
                MessageBox.Show("1");
            }
            public static void p2()
            {
                MessageBox.Show("2");
            }
        }
    }
