        private byte[] GetImageBytes(Image img)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                ImageConverter imgConverter = new ImageConverter();
                return (byte[])imgConverter.ConvertTo(img, typeof(byte[]));
            }
        }
