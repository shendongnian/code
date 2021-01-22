        private void Form1_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 10;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }
        int aa = 0;
        void t_Tick(object sender, EventArgs e)
        {
            this.Text = aa++.ToString();
        }
