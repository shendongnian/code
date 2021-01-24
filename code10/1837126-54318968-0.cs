    //Global Variable
    Bitmap bm = null;
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawImage(bitmap, 0,0);
    }
    public void ClearForm()
    {
        bm = null;
        pictureBox1.Invalidate();
    }
