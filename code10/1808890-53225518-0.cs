     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button1.Click += (s, e) => Button1_Click(s, e);
            //this.button1.Click += Button1_Click1;
            MessageBox.Show("The End!");
        }
        private async Task Button1_Click(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            MessageBox.Show("With Sync");
        }
        private void Button1_Click1(object sender, EventArgs e)
        {
            MessageBox.Show("Without async");
        }
    }
