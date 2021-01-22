    void Page_Load(object sender, EventArgs args) {
        string mime = "image/jpeg";
        Response.ContentType = mime;
    
        Bitmap b = GetImageForTime(DateTime.Now);
    
        var params = new EncoderParameters(1);
        params.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
    
        var codec = ImageCodecInfo.GetImageEncoders().Where(i => i.MimeType == mime).SingleOrDefault();
    
        if(codec != null)
            b.Save(Response.OutputStream, codec, params);
    }
