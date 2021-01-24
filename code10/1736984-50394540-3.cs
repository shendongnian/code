    public void setImage()
    {
       Bitmap dummy = pictureBox3.BackgroundImage;
       pictureBox3.BackgroundImage = null;
       if (dummy != bnull) dummy.Dispose();
       pictureBox3.BackgroundImage = _img;       
       this.ShowDialog();
    }
