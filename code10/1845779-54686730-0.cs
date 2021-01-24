        private void Graph_Load(object sender, EventArgs e)
        {
            {
                System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
                label1.Text = DateTime.Now.ToString("HH:mm:ss");
                timer1.Interval = 60000;//1 minutes
                timer1.Tick += new System.EventHandler(Timer1_Tick);
                timer1.Start();
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
            Refresh(); // OR Invalidate(); OR Update();
        }     
