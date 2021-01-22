    static bool IsValidImage(string filePath)
    {
        return File.Exists(filePath) && IsValidImage(new FileStream(filePath, FileMode.Open, FileAccess.Read));
    }
    static bool IsValidImage(Stream imageStream)
    {
        if(imageStream.Length > 0)
        {
            byte[] header = new byte[4]; // Change size if needed.
            string[] imageHeaders = new[]{
                    "\xFF\xD8", // JPEG
                    "BM",       // BMP
                    "GIF",      // GIF
                    Encoding.ASCII.GetString(new byte[]{137, 80, 78, 71})}; // PNG
            imageStream.Read(header, 0, header.Length);
            bool isImageHeader = imageHeaders.Count(str => Encoding.ASCII.GetString(header).StartsWith(str)) > 0;
            if (isImageHeader == true)
            {
                try
                {
                    Image.FromStream(imageStream).Dispose();
                    imageStream.Close();
                    return true;
                }
                catch
                {
                }
            }
        }
        
        imageStream.Close();
        return false;
    }
