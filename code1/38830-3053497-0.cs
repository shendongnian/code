        public class ScannerTextBox : TextBox
        {
            public bool BarcodeOnly { get; set; }
    
            Timer timer;
    
            private void InitializeComponent()
            {
                this.SuspendLayout();
    
                this.ResumeLayout(false);
            }
    
            void timer_Tick(object sender, EventArgs e)
            {
                if (BarcodeOnly == true)
                {
                    Text = "";
                }
    
                timer.Enabled = false;
            }
    
    
            protected override void OnKeyPress(KeyPressEventArgs e)
            {
                base.OnKeyPress(e);
    
                if (BarcodeOnly == true)
                {
                    if (timer == null)
                    {
                        timer = new Timer();
                        timer.Interval = 200;
                        timer.Tick += new EventHandler(timer_Tick);
                        timer.Enabled = false;
                    }
                    timer.Enabled = true;
                }
    
                if (e.KeyChar == '\r')
                {
                    if (BarcodeOnly == true && timer != null)
                    {
                        timer.Enabled = false;
                    }
                }
            }
        }
