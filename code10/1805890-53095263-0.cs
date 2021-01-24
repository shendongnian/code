    private static void compressBitmap(ImageData imgData)
    {
        using (Bitmap imageRaw = new Bitmap(imgData.bmpFilePath))
        { 
            using (ConvertBitmap imageCompressed = new ConvertBitmap())
            {
                imageCompressed.Convert(imageRaw, 4).Save(imgData.bmpFilePath);
            }
        }
    }
