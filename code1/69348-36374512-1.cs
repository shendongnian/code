    public static void ToTransparent(this System.Windows.Forms.Button Button,
         System.Drawing.Color TransparentColor)
    {
        Bitmap bmp = ((Bitmap)Button.Image);
        bmp.MakeTransparent(TransparentColor);
        int x = (Button.Width - bmp.Width) / 2;
        int y = (Button.Height - bmp.Height) / 2;
        Graphics gr = Button.CreateGraphics();
        gr.DrawImage(bmp, x, y);
    }
