    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pd[0](1);
            pd[1](2);
        }
        public delegate void delegates(int par);
        static delegates[] pd = new delegates[] 
                                         { 
                                          new delegates(MyClass.p1), 
                                          new delegates(MyClass.p2) 
                                         };
        public static class MyClass
        {
            public static void p1(int par)
            {
                MessageBox.Show(par.ToString());
            }
            public static void p2(int par)
            {
                MessageBox.Show(par.ToString());
            }
            
            
        }
    }
