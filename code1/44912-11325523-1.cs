    public static BitmapSource LoadImageNoLock(string path)
    {
        while (true)
        {
            try
            {
                var memStream = new MemoryStream(File.ReadAllBytes(path));
                var img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = memStream;
                img.EndInit();
                return img;
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
