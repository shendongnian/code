    public partial class Form1 : Form
    {
        List<string> strings = new List<String>() { "Hello", "world", "!" };
        public Form1()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string returnString = await DoStuff1();
        }
        private async Task<string> DoStuff1()
        {
            foreach (string s in strings)
            {
                MessageBox.Show(s);
                await Task.Yield();
                await Task.Delay(1000);
            }
            return "ASYNC DONE";
        }
    }
