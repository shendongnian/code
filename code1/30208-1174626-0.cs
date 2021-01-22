    public partial class Form1 : Form
    {
        OFDThread ofdThread;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ofdThread = new OFDThread();
            ofdThread.Show();
        }
    }
    public class OFDThread
    {
        private Thread t;
        private DialogResult result;
        public OFDThread()
        {
            t = new Thread(new ParameterizedThreadStart(ShowOFD));
            t.SetApartmentState(ApartmentState.STA);
        }
        public DialogResult DialogResult { get { return this.result; } }
        public void Show()
        {
            t.Start(this);
        }
        private void ShowOFD(object o)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            result = ofd.ShowDialog();
        }
    }
