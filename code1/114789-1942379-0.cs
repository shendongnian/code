    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        string someValue = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            
            Thread t = new Thread(delegate() { someValue = "asdf"; });
            t.Start();
            t.Join();
            //while (t.IsAlive) Thread.Sleep(1000);
            System.Diagnostics.Debug.Print(someValue);
        }
    }
