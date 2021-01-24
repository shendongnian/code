    var byteStream = Convert.FromBase64String("Base64 String");
            Image image = null;
            using (MemoryStream memoryStream = new MemoryStream(byteStream))
            {
                using (GZipStream gzip = new GZipStream(memoryStream,CompressionMode.Decompress))
                {
                    image = Image.FromStream(gzip);
                }
            }
            image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
            image.Save(@"G:\label123.png");
