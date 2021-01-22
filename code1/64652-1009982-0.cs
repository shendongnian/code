    partial class TimedModalForm : Form
    {
        private Timer timer;
        public TimedModalForm()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += CloseForm;
            timer.Start();
        }
        private void CloseForm(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            this.DialogResult = DialogResult.OK;
        }
    }
