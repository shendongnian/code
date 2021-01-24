     using ClassLibrary1;
     namespace MainForm
    { 
        public partial class Form1 : Form
        {
             public Form1()
            {
                InitializeComponent();
            }
        private void button1_Click(object sender, EventArgs e)
        {
            int s = 1;
            int a= 1;
            int b = 1;
            int c = 1;
            // how could I use class B in this area, since it was public in ClassLibrary2 ??
            B cc = new B(s, a, b, c);
        }
    }
}
