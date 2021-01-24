    public partial class Form1 : Form
    {
        Timer t = new Timer();
        public Form1()
        {
            InitializeComponent();
            t.Interval = 1000;
            t.Tick += ((ss, ee) => {
                t.Enabled = false;
                focusChangedCounter = 0;
                focusChangedBufferTimer.Stop();
                focusChangedBufferTimer = null;
            });
        }
        private void HandleFocusChangedEvent(object sender, EventArgs e)
        {
            t.Enabled = false;
            t.Enabled = true;
        }
    }
