    byte[] fileData = null;
    using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
    {
        fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
    }
    ImageConverter imageConverter = new System.Drawing.ImageConverter();
    System.Drawing.Image image = imageConverter.ConvertFrom(fileData) as System.Drawing.Image;
    image.Save(imageFullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
