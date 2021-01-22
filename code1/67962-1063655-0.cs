            private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation=@"C:\Documents and Settings\tr1g3800\Desktop\WALKING\30P\100000.jpg" ;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(@"C:\Documents and Settings\tr1g3800\Desktop\WALKING\30P\100000test.jpg",ImageFormat.Jpeg);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
          
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Graphics gr = Graphics.FromImage(bmp);
            Pen p = new Pen(Color.Red);
            p.Width = 5.0f;
            gr.DrawRectangle(p, 1, 2, 30, 40);
            pictureBox1.Image = bmp;
        }
