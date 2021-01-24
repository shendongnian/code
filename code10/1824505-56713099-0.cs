    public static string Base64ToImageStream(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                using (var msOut = new MemoryStream())
                {
                    MagickReadSettings readSettings = new MagickReadSettings()
                    {
                        Format = MagickFormat.Svg,
                        Width = 60,
                        Height = 40,
                        BackgroundColor = MagickColors.Transparent
                    };
                    using (MagickImage image = new MagickImage(imageBytes, readSettings))
                    {
                        image.Format = MagickFormat.Png; // Specify the format you need
                        image.Write(msOut);
                        byte[] data = image.ToByteArray();
                        return Convert.ToBase64String(data);
                        // In case if you want the output in stream
                        // byte[] imgByte = Convert.FromBase64String(pngBase64);
                        // var pngStream = new MemoryStream(imgByte, 0, imgByte.Length);
                        // return pngStream;
                    }
                }
            }            
        }
