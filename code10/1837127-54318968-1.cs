    private void btnOpenfile_Click(object sender, EventArgs e)
    {
        // open file dialog   
        OpenFileDialog open = new OpenFileDialog();
        // image filters  
        open.Filter = "Image Files (*.png)|*.png";
        if (open.ShowDialog() == DialogResult.OK)
        {
            // display image in picture box  
            bm = new Bitmap(open.FileName);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            tbFilepath.Text = open.FileName;
            pictureBox1.Invalidate();
        }
    }
