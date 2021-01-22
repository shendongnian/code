    public partial class Form1 : Form
    {
        private System.Threading.Timer testTimer;
        ...
        public void Form1_Load(object sender, EventArgs e)
        {
            TimerCallback timerDelegate = new TimerCallback(tick);
            testTimer = new System.Threading.Timer(timerDelegate, null, 1000, 1000);
        }
    }
