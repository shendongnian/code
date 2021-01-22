    Bitmap b = Bitmap.FromFile(sourceFilename);
    Bitmap output = new Bitmap(b.Width * numTimes, b.Height);
    Graphics g = Graphics.FromImage(output);
    
    for (int i = 0; i < numTimes; i++) {
      g.DrawImage(b, i * b.Width, 0);
    }
    
    // do whatever with the image, here we'll output it
    output.Save(outputFilename);
    // make sure to clean up too
    g.Dispose();
    b.Dispose();
    output.Dispose();
