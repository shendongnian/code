    public partial class Form1 : Form
    {
        private bool shouldRunAgain;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10000;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            shouldRunAgain = true;
            RunMyFunction();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            shouldRunAgain = false;
        }
        private void RunMyFunction()
        {
            try
            {
                // do something
                timer1.Start();
            }
            catch (Exception)
            {
                // handle exceptions
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (shouldRunAgain)
            {
                shouldRunAgain = false;
                RunMyFunction();
            }
        }
    }
