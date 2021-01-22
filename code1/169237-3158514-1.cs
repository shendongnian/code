    private int clickCounter = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            clickCounter++;
            lblClickCount.Text = clickCounter.ToString();
        }
        decimal sure = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sure--;
            lblRemainingTime.Text = sure.ToString();
            Application.DoEvents();
            if (sure == 0)
            {
                timer1.Stop();
                MessageBox.Show("Süre doldu. Toplam tiklama sayisi:" + clickCounter.ToString());
            }
        }
