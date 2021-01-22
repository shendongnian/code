    private void button1_Click(object sender, EventArgs e)
    {
        Bitmap bmp = CreateBarcode("Ziggy12345");
        this.pb.Image = bmp;
        try { 
        // save to root of boot drive
        // does nothing on my system: no Error, No File
         bmp.Save(@"C:\zBarCodeDIRECT.gif", ImageFormat.Gif);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        // save BMP to file
        SaveImageFile(@"c:\Temp\zBarCodeBITMAP.gif",
                          ImageFormat.Gif, bmp, 100);
        // save PicBox image
        SaveImageFile(@"c:\Temp\zBarCodePICBOX.gif",
                    ImageFormat.Gif, this.pb.Image, 100);
        // Try to save to same file with bmp opened from it
        Bitmap myBmp = (Bitmap)Image.FromFile(@"c:\Temp\zBarCodeBITMAP.gif");
        // A generic Error in GDI
        myBmp.Save(@"c:\Temp\zBarCodeBITMAP.gif", ImageFormat.Gif);
    }
