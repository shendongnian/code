     protected void onClickHandler(object sender, EventArgs e)
     {
        if (((PictureBox)sender).BorderStyle == BorderStyle.None)
        {
            ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
        }
        else
        {
            ((PictureBox)sender).BorderStyle = BorderStyle.None;
        }
    }
