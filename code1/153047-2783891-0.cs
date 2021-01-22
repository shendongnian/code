    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoCount();
        }
        public void DoCount()
        {
            Thread t = new Thread(new ThreadStart(delegate
            {
               for (int i = 0; i < 100; i++)
               {
                   this.Invoke((Action) delegate { objTextBox.Text = i.ToString(); });
                   Thread.Sleep(1000);
               }
            }));
            t.IsBackground = true;
            t.Start();
        }
    }
