    using (var stream = new FileStream(@"meme.txt", FileMode.OpenOrCreate, FileAccess.Write))
    {
       using (var writer = new StreamWriter(stream))
       {
          for (var imageNumber = 0; imageNumber <= 7600; imageNumber++)
          {
             var dir = @"C:\Users\Admin\source\repos\badapple\ayy\ba\ba";
    
             var fileName = Path.Combine(dir, $"{imageNumber:D5}.jpg");
    
             if (File.Exists(fileName))
             {
                throw new FileNotFoundException($"Woah, what now : {fileName}");
             }
    
             using (var image = new Bitmap(fileName, true))
             {
                for (var y = 0; y < image.Height; y++)
                {
                   for (var x = 0; x < image.Width; x++)
                   {
                      var pixel = image.GetPixel(x, y);
                      writer.Write(pixel.R > 200 ? "#" : " ");
                   }
    
                   writer.WriteLine();
                }
             }
          }
       }
    }
