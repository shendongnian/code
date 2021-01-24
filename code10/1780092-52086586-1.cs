    private void Start_Click( object sender, EventArgs e ) {
        //create both bitmap and graphics once!
        bm = new Bitmap( Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height );
        g = Graphics.FromImage( bm );
        pictureBox1.Image = bm; //Just once!
        basePath = sel.ToString();
        basePath = @"C:\Users\sim\Videos\Captures";
        videowriter = new VideoFileWriter();
        videowriter.Open(basePath + "timelapse.avi", Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 9, VideoCodec.MPEG4, 1200000);
        timer1.Enabled = true;
    }
