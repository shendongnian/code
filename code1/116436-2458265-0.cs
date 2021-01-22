    bm.SelectActiveFrame(FrameDimension.Page, k);
    
    iTextSharp.text.Image img;
    using(System.IO.MemoryStream mem = new System.IO.MemoryStream())
    {
        // This jumps all the inbuilt processing iTextSharp will perform
        // This will create a larger pdf though
        bm.Save(mem, System.Drawing.Imaging.ImageFormat.Png);
        img = iTextSharp.text.Image.GetInstance(mem.ToArray());
    }
    
    img.ScalePercent(72f / 200f * 100);
