    MemoryStream ms = new MemoryStream();
    Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
    panel1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, panel1.Width, panel1.Height));
    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); //you could ave in BPM, PNG  etc format.
    byte[] Pic_arr = new byte[ms.Length];
    ms.Position = 0;
    ms.Read(Pic_arr, 0, Pic_arr.Length);
    ms.Close();
