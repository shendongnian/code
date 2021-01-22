    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new Thread(SampleFunction).Start();
        }
    
        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] {value});
                return;
            }
            textBox1.Text += value;
        }
    
        void SampleFunction()
        {
            for(int i = 0; i<5; i++)
            {
                AppendTextBox("hi.  ");
                Thead.Sleep(1000);
            }
        }
    
    }
