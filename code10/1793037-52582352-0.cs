        private void button1_Paint(object sender, PaintEventArgs e)
        {
            Font f = new Font("Tahoma", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            Button btn = ((Button)sender);
            e.Graphics.DrawString(btn.Text[0].ToString(), f, new SolidBrush(Color.Red), new Point(10, 10));
            e.Graphics.DrawString(btn.Text.Substring(1), f, new SolidBrush(Color.Black), new Point(22, 15));
        }
