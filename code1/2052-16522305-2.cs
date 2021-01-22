    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            // if needed, the singleton will restore this window
            Program.Singleton.OnWndProc(this, m, true);
            // TODO: handle specific messages here if needed
            base.WndProc(ref m);
        }
    }
