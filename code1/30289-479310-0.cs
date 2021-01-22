    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Form2 f2 = new Form2();
            f2.MouseWheel += new MouseEventHandler(panel1_MouseWheel);
            f2.MouseMove += new MouseEventHandler(panel1_MouseWheel);
            f2.Show(this);
        }
        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta != 0) Console.Out.WriteLine(e.Delta);
        }
    }
