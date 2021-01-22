    public ActionResult ReduceFileSize(string ImageURL, long MAX_PHOTO_SIZE) //KB
    {
        var photo = Server.MapPath("~/" + ImageURL); //Files/somefiles/2018/DOC_82401583cb534b95a10252d29a1eb4ee_1.jpg
        var photoName = Path.GetFileNameWithoutExtension(photo);
        var fi = new FileInfo(photo);
        //const long MAX_PHOTO_SIZE = 100; //KB //109600;
        var MAX_PHOTO_SIZE_BYTES = (MAX_PHOTO_SIZE * 1000);
        if (fi.Length > MAX_PHOTO_SIZE_BYTES)
        {
            using (var image = Image.FromFile(photo))
            {
                using (var mstream = DownscaleImage(image, MAX_PHOTO_SIZE_BYTES))
                {
                    //Convert the memorystream to an array of bytes.
                    byte[] byteArray = mstream.ToArray();
                    //Clean up the memory stream
                    mstream.Flush();
                    mstream.Close();
                    // Clear all content output from the buffer stream
                    Response.Clear();
                    // Add a HTTP header to the output stream that specifies the default filename
                    // for the browser's download dialog
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + fi.Name);
                    // Add a HTTP header to the output stream that contains the 
                    // content length(File Size). This lets the browser know how much data is being transfered
                    Response.AddHeader("Content-Length", byteArray.Length.ToString());
                    // Set the HTTP MIME type of the output stream
                    Response.ContentType = "application/octet-stream";
                    // Write the data out to the client.
                    Response.BinaryWrite(byteArray);
                }
            }
        }
        else
        {
            return null;
        }
        return null;
    }
    private static MemoryStream DownscaleImage(Image photo, long MAX_PHOTO_SIZE_BYTES)
    {
        MemoryStream resizedPhotoStream = new MemoryStream();
        long resizedSize = 0;
        var quality = 93;
        //long lastSizeDifference = 0;
        do
        {
            resizedPhotoStream.SetLength(0);
            EncoderParameters eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);
            ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
            photo.Save(resizedPhotoStream, ici, eps);
            resizedSize = resizedPhotoStream.Length;
            //long sizeDifference = resizedSize - MAX_PHOTO_SIZE;
            //Console.WriteLine(resizedSize + "(" + sizeDifference + " " + (lastSizeDifference - sizeDifference) + ")");
            //lastSizeDifference = sizeDifference;
            quality--;
        } while (resizedSize > MAX_PHOTO_SIZE_BYTES);
        resizedPhotoStream.Seek(0, SeekOrigin.Begin);
        return resizedPhotoStream;
    }
    private static ImageCodecInfo GetEncoderInfo(String mimeType)
    {
        int j;
        ImageCodecInfo[] encoders;
        encoders = ImageCodecInfo.GetImageEncoders();
        for (j = 0; j < encoders.Length; ++j)
        {
            if (encoders[j].MimeType == mimeType)
                return encoders[j];
        }
        return null;
    }
