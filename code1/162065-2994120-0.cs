    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            tabPage2.MouseMove += new MouseEventHandler(tabPage2_MouseMove);
        }
        private void tabPage2_MouseMove(object sender, MouseEventArgs e) {
            Console.WriteLine(e.Location.ToString());
        }
    }
