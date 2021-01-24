        using (MemoryStream thumbnailStream = new MemoryStream())
        {
            // Save the thumbnail to the memory stream
            thumb.Save(thumbnailStream, image.RawFormat);
  
            // Reset the seek position to the begining
            thumbnailStream.Seek(0, SeekOrigin.Begin);
            // The name of the new thumbnail
            string thumbnailFilename = string.Format("thumbnail_{0}", filename);
            // The name along with the exact path to the thumbnail
            string thumbnailPath = Path.Combine(file.ContentId, thumbnailFilename);
            // Write the thumbnail to storage
            Storage.CreateAsync(thumbnailStream, thumbnailPath);
        }
