    private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
    
    private void Button1_Click(object sender, EventArgs e)
        {     
            timer1.Interval = 900000;//5 minutes
            timer1.Tick += new System.EventHandler(Timer1_Tick);
            timer1.Start();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //do whatever you want 
            RefreshMyForm();
        }
        private void RefreshMyForm()
        {
            this.Hide();
            Graph1 graph = new Graph1();
            graph.Show();
    
        }
