    public partial class SplashForm : Form
    {
        //  default stuff
    
        public static void Splash()
        {
            var s = new SplashForm();
            s.Show();
            s.Update();// force paint
        }
        private void SplashForm_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 1; // wait for EventLoop
            t.Tick += GoAway;
            t.Enabled = true;
        }
    
        private void GoAway(object sender, EventArgs e)
        {
            this.Close();
        }
    }
