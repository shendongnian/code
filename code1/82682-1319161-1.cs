    Bitmap bmpClone = null;
    
    using (Bitmap bmp = new Bitmap("C:\\test.jpg"))
    {
        bmpClone = (Bitmap)bmp.Clone();
    }
                    
    bmpClone.RotateFlip(RotateFlipType.Rotate180FlipNone);
    bmpClone.Save("C:\\test.jpg");
    bmpClone.Dispose();
