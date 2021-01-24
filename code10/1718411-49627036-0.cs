    private void AddPictureBox(string IP, Bitmap image) {
        PictureBox pbs = new PictureBox();
        pbs.Image = image;
        pbs.Tag = IP;
        pbs.Height = 169;
        pbs.Width = 289;
        pbs.SizeMode = PictureBoxSizeMode.StretchImage;
        pbs.Visible = true;
     
        tabControl1.TabPages[0].Controls.Add(pbs); //This will display picturebox inside the Tab control with an id : tabControl1
        boxes.Add(pbs); 
    }
