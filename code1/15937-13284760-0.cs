    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            delegates[0]();
            delegates[1]();
        }
        public delegate void pd();
        static pd[] delegates = new pd[] { new pd( MyClass.p1 ),new pd( MyClass.p2)};
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
