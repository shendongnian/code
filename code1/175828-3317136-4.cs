    IDataObject data = Clipboard.GetDataObject();
    
    if (data.GetDataPresent(DataFormats.Bitmap))
    {
      Bitmap bitmap = (data.GetData(DataFormats.Bitmap,true) as Bitmap);
    
      bitmap.Save("image.bmp",System.Drawing.Imaging.ImageFormat.Bmp);
      bitmap.Save("image.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
    
    }
