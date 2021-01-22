    namespace AnimateUI
    {
        public partial class Form1 : Form
        {
            public delegate void ProcessAnimation(bool show);
            ProcessAnimation pa;
    
    
            public Form1()
            {
                InitializeComponent();
                pa = this.ShowAnimation;
                pictureBox1.Visible = false;
            }
    
            private void ShowAnimation(bool show)
            {
                if (show)
                {
                    pictureBox1.Visible = true;
                }
                else
                {
                    pictureBox1.Visible = false;
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Thread tr = new Thread(StartTask);
                tr.Start();
            }
    
            private void StartTask()
            {
                if (!this.IsHandleCreated)
                    this.CreateControl();
    
                this.Invoke(this.pa, true);
                System.Threading.Thread.Sleep(15000);
                this.Invoke(this.pa, false);
            }
    
        }
    
    }
