         private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Location.X + 5, label1.Location.Y);
            if (label1.Location.X > this.Width)
            {
                label1.Location = new Point(0 - label1.Width, label1.Location.Y);
                label1.Text = "Your Message Here ";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
