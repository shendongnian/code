        private void button1_Click(object sender, EventArgs e)
        {
            ShowMyImage();
        }
        private void ShowMyImage()
        {
            string[] pics = new string[2];
            pics[0] = "E:\\images\\image0.jpg";
            pics[1] = "E:\\images\\image1.jpg";
            var picbox = new PictureBox();
            picbox.Image = Bitmap.FromFile(@pics[0]);
            picbox.Dock = DockStyle.Fill;
            panel1.Controls.Add(picbox);
            
        }
