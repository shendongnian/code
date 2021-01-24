        private volatile Boolean b;
        private async void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            b = true;
            while (b)
            {
                int r = rnd.Next(0, 254);
                int n = rnd.Next(0, 254);
                int d = rnd.Next(0, 254);
                this.BackColor = Color.FromArgb(r, n, d);
                await Task.Delay(200);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            b = false;
        }
    }
