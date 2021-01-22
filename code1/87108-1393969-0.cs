    class MyPictureBox : PictureBox
    {
        protected void this_Click(object sender, EventArgs e)
        {
            if (this.BorderStyle == BorderStyle.None)
            {
                this.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                this.BorderStyle = BorderStyle.None;
            }
        }
    }
