    private void pictureBox_Paint( object sender, PaintEventArgs e ) {
        PictureBox picbox = (PictureBox)sender;
        var color = ColorTranslator.FromHtml( "#ff9900" );
        var rc = picbox.ClientRectangle;
        rc.Inflate( -1, -1 );
        ControlPaint.DrawBorder( e.Graphics, rc, color, 3, ButtonBorderStyle.Solid, color, 3, 
                                 ButtonBorderStyle.Solid, color, 3, ButtonBorderStyle.Solid, 
                                 color, 3, ButtonBorderStyle.Solid );
    }
