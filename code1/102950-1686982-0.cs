    System.Drawing.Bitmap resizedImage;
    using(System.Drawing.Image originalImage = System.Drawing.Image.FromFile(filePath))
        resizedImage = new System.Drawing.Bitmap(originalImage, newSize);
    // Save resized picture
    resizedImage.Save(resizedFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
    resizedImage.Dispose();
