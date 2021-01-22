    private void RunTest()
    {
        // byte array that can be stored in DB
        byte[] iba;
        // image object to display in picturebox or used to save to file system.
        iba = ReadImage("D:\\Images\\Image01.jpg");
        using (Image img = DeserializeImage(iba))
        {
            SaveImage(img, "D:\\Images\\Image01_Copy.jpg");
        }
        iba = ReadImage("D:\\Images\\Image02.png");
        using (Image img1 = DeserializeImage(iba))
        {
            SaveImage(img1, "D:\\Images\\Image02_Copy.png");
        }
        iba = ReadImage("D:\\Images\\Image03.gif");
        using (var img2 = DeserializeImage(iba))
        {
            SaveImage(img2, "D:\\Images\\Image03_Copy.gif");
        }
        MessageBox.Show("Test Complete");
    }
    private static byte[] ReadImage(String filePath)
    {
        // This seems to be the easiest way to serialize an image file
        // however it would be good to take a image object as an argument
        // in this method.
        using (var fs = new FileStream(filePath, FileMode.Open))
        {
            Int32 fslength = Convert.ToInt32(fs.Length);
            var iba = new byte[fslength];
            fs.Read(iba, 0, fslength);
            return iba;
        }
    }
    private static Image DeserializeImage(byte[] imageByteArray)
    {
        using (var ms = new MemoryStream(imageByteArray))
        {
            return Image.FromStream(ms);
        }
    }
    private static void SaveImage(Image imageObject, string filePath)
    {
        // I could only get this method to work for .png files.
        // imageObject.Save(filePath, imageObject.RawFormat);
        // This method works with .jpg, .png and .gif
        // Need to copy image before saving.
        using (Image img = new Bitmap(imageObject.Width, imageObject.Height))
        {
            using (Graphics tg = Graphics.FromImage(img))
            {
                tg.DrawImage(imageObject, 0, 0);
            }
            img.Save(filePath, img.RawFormat);
        }
        return;
    }
