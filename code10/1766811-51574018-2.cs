    public partial class Form1 : Form
    {
        System.Timers.Timer t = new System.Timers.Timer(1000);
        List<string> strings = new List<String>() { "Hello", "world", "!" };
        public Form1()
        {
            InitializeComponent();
        }
        private async void button1_Click_1(object sender, EventArgs e)
        {
            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Elapsed += async (s, ev) => await DoStuff1();
            t.Start();
        }
        private async Task<string> DoStuff1()
        {
            foreach (string s in strings)
            {
                MessageBox.Show(s);
            }
            return "ASYNC DONE";
        }
    }
