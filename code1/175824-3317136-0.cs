    IDataObject data = Clipboard.GetDataObject();
    
    if (data.GetDataPresent(DataFormats.Bitmap))
    {
      Image image = (data.GetData(DataFormats.Bitmap,true) as Image);
    
      image.Save("image.bmp",System.Drawing.Imaging.ImageFormat.Bmp);
      image.Save("image.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
    
    }
