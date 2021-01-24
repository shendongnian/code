    private void Images_M_E(object sender, EventArgs e)
    {
        PictureBox pb = sender as PictureBox;  // here we get a reference to the actual pbox
        pb.BorderStyle = BorderStyle.FixedSingle;   // do what you..
    }
    private void Images_M_L(object sender, EventArgs e)
    {
        PictureBox pb = sender as PictureBox;
        pb.BorderStyle = BorderStyle.None;   ..want to do here
    }
