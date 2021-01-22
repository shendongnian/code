    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            Bitmap image1 = (Bitmap)Image.FromFile(@"C:\temp\mybrush.bmp", true);
    
            TextureBrush t = new TextureBrush(image1);
            t.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.FillEllipse(t, new RectangleF(90.0F, 110.0F, 100, 100));
            formGraphics.Dispose();
    
        }
        catch (System.IO.FileNotFoundException)
        {
            MessageBox.Show("Image file not found!");
        }
    }
