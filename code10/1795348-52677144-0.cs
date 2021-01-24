    using (Bitmap image = CaptchaUtils.ImageGeneratorFactory(drawingModel).Generate(drawingModel))
    {
        using (MemoryStream ms = new MemoryStream())
        {
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.WriteTo(response.OutputStream);
        }
    }
