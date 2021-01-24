    private void Btn_Screenshot_Click(object sender, EventArgs e)
    {
        using (var bmp = ScreenCapture.Capture(this.rtb_Result))
        {
            var result = saveScreenshotDialog.ShowDialog();
            var fileName = saveScreenshotDialog.FileName;
            if (result == DialogResult.OK)
            {
                ScreenCapture.Save(bmp, fileName);
            }
        }
    }
    public static Bitmap Capture(RichTextBox rtb)
    {
        rtb.Update();  // Ensure RTB fully painted
        Bitmap bmp = new Bitmap(rtb.Width, rtb.Height);
        using (Graphics gr = Graphics.FromImage(bmp))
        {
            gr.CopyFromScreen(rtb.PointToScreen(Point.Empty), Point.Empty, rtb.Size);
        }
        return bmp;
    }
    public static void Save(Bitmap bmp, string filename)
    {
        bmp.Save(filename, ImageFormat.Jpeg);
    }
