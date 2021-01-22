     byte[] bytes = System.Convert.FromBase64String(xDocument.SelectSingleNode("Response/Images/Photo").InnerText);
       
    
       System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
    
       System.Drawing.Bitmap b = new System.Drawing.Bitmap(ms); //(Bitmap)System.Drawing.Image.FromStream(ms);
    
       System.Drawing.Imaging.FrameDimension frameDim;
       frameDim = new System.Drawing.Imaging.FrameDimension(b.FrameDimensionsList[0]);
    
    
       int NumberOfFrames = b.GetFrameCount(frameDim);
       string[] paths = new string[NumberOfFrames];
    
       for (int i = 0; i < NumberOfFrames; i++)
       {
         b.SelectActiveFrame(frameDim, i);
    
         System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(b);
         paths[i] = imagePathfile.Remove(imagePathfile.Length - 4, 4) + i.ToString() + ".gif";
    
         bmp.Save(paths[i], System.Drawing.Imaging.ImageFormat.Gif);
         //bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
         bmp.Dispose();
       }
    
        Image1.Src = paths[0];
        //Check if there's more than 1 image cause its a TIFF
        if (paths.Length>1)
        {
          Image2.Src = paths[1];  
        }
