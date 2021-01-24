    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        List<float> zooms = new List<float>()
        { 0.1f, 0.2f, 0.5f, 0.75f, 1f, 2, 3, 4, 6, 8, 10};
        zoom = zooms[trackBar1.Value];
        int w = (int)(pictureBox2.Image.Width * zoom);
        int h = (int)(pictureBox2.Image.Height * zoom);
        pictureBox2.ClientSize = new Size(w, h);
        lbl_zoom.Text = "zoom: " + (zoom*100).ToString("0.0");
    }
