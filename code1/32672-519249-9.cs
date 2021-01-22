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
            // Gets executed on a seperate thread and 
            // doesn't block the UI while sleeping
            for(int i = 0; i<5; i++)
            {
                AppendTextBox("hi.  ");
                Thread.Sleep(1000);
            }
        }
    }
