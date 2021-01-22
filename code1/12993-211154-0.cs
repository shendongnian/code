    static bool IsValidImage(string filePath)
    {
        return File.Exists(filePath) && IsValidImage(new FileStream(filePath, FileMode.Open, FileAccess.Read));
    }
    static bool IsValidImage(Stream imageStream)
    {
        if(imageStream.Length > 0)
        {
            byte[] header = new byte[4];
            string[] imageHeaders = new[]{
                    "\xFF\xD8", Encoding.ASCII.GetString(new byte[]{137, 80, 78, 71}), "BM", "GIF"};
            imageStream.Read(header, 0, 4);
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
        return false;
    }
