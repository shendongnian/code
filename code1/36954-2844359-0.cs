    /// <summary>
    /// Sends a given image to the client browser as a PNG encoded image.
    /// </summary>
    /// <param name="image">The image object to send.</param>
    private void SendImage(Image image)
    {
        // Get the PNG image codec
        ImageCodecInfo codec = GetCodec("image/png");
    
        // Configure to encode at high quality
        using (EncoderParameters ep = new EncoderParameters())
        {
            ep.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
    
            // Encode the image
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, codec, ep);
    
                // Send the encoded image to the browser
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "image/png";
                ms.WriteTo(HttpContext.Current.Response.OutputStream);
            }
        }
    }
