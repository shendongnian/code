    for(int i = 0; i < filenames.Count; i++)
    {
        using (Stream imageStream = File.OpenRead(filenames[i]))
        {
            foreach(var stream = ImageProcessing(imageStream))
            {
                using(stream)
                {        
                     using(var image = System.Drawing.Image.FromStream(stream))
                         image.Save();
                }
            }
        }
    }
