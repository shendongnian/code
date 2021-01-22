    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Action countUp = this.CountUp;
            countUp.BeginInvoke(null, null);
        }
        private void CountUp()
        {
            for (int i = 0; i < 100; i++)
            {
                this.Invoke(new Action<string>(UpdateTextBox), new object[] { i.ToString() });
                Thread.Sleep(100);
            }
        }
        private void UpdateTextBox(string text)
        {
            this.textBox1.Text = text;
        }
    }
