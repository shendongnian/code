    public partial class TempForm : Form
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        double seconds = 3;
        public TempForm(int secs, string text)
        {
            InitializeComponent();
            //Custom property to dock it to down right to the screen
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
            t = new System.Windows.Forms.Timer();
            this.seconds = (secs != 0) ? secs : this.seconds;
            richTextBox1.Text = text;
        }
        private void TempForm_Load(object sender, EventArgs e)
        {
            t.Interval = (int)(seconds * 1000);
            t.Tick += new EventHandler(CloseForm);
            t.Start();
        }
        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        public static void Show(int seconds, string text)
        {
            TempForm tf = new TempForm(seconds, text);
            tf.Show();
        }
    }
