    System.Drawing.Image tempimg = System.Drawing.Image.FromFile(temppath);
    System.Drawing.Image img = (System.Drawing.Image) tempimg.Clone();
    tempimg.Dispose();
    
    System.Drawing.Image img2 = resizeImage(img, 200, 200);
    img2.Save(newpath);
    img2.Dispose();
    img.Dispose();
    
    File.Delete(temppath);
