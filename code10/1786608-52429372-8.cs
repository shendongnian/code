    public partial class Form1 : CustomForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = @"C:\Users\ok\Downloads\ok.mp4";
        }
        // To start playing video and etc when form being maximized
        protected override void OnStart(CustomForm Sender)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        // To stop playing video and etc when form being minimized
        protected override void OnStop(CustomForm Sender)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }
    }
