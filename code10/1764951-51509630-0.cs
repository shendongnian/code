        public static Image BitmapToBytes(byte[] image, ImageFormat pFormat)
        {
            var imageObject = new Bitmap(new MemoryStream(image));
            var stream = new MemoryStream();
            imageObject.Save(stream, pFormat);
            return new Bitmap(stream);
        }
