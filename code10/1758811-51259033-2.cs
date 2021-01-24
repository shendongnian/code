    public partial class Form1 : Form
    {
        StatusBar statusBar1 = null;
        public Form1()
        {
            InitializeComponent();
            this.Shown += new System.EventHandler(this.Form1_Shown);
        }
        
        
        public void CreateMyStatusBar(string msg = "Ready")
        {
            if (statusBar1 == null)
            {
                statusBar1 = new StatusBar();
                this.Controls.Add(statusBar1);
            }
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    statusBar1.Text = msg;
                    statusBar1.Update();
                }));
            }
            else
            {
                statusBar1.Text = msg;
            }
            statusBar1.Invalidate();
            statusBar1.Refresh();
            statusBar1.Update();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            CreateMyStatusBar("one");
            System.Threading.Thread.Sleep(5000);//Wait - and blocks UI :(
            CreateMyStatusBar("two");
        }
    }
