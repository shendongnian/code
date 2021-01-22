        private void button1_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            try {
                Bitmap bmp = new Bitmap(openFileDialog1.FileName);
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = bmp;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Could not load image");
            }
        }
