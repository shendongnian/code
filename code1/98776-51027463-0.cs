        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar1.Value += 1;
            if(ProgressBar1.Value==100)
            {
                timer1.Stop();
                Form1 f1 = new Form1();
                this.Hide();
                f1.Show();
            }
        }`
