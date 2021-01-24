    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = false;
        }
        private MyAwaitable awaitable;
        private async void buttonStart_Click(object sender, EventArgs e)
        {
            awaitable = new MyAwaitable();
            progressBar.Visible = true;
            var result = await awaitable; //.ConfigureAwait(false); from foreign thread this throws an exception
            progressBar.Visible = false;
            MessageBox.Show(result.ToString());
        }
        private void buttonStopUIThread_Click(object sender, EventArgs e) =>
            awaitable.Finish(new Random().Next());
        private void buttonStopForeignThread_Click(object sender, EventArgs e) =>
            Task.Run(() => awaitable.Finish(new Random().Next()));
     }
