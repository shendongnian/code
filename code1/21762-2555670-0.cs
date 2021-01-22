        public static Image ToImage(this byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            using (var image = Image.FromStream(stream, false, true))
            {
                return new Bitmap(image);
            }
        }
        [Test]
        public void ShouldCreateImageThatCanBeSavedWithoutOpenStream()
        {
            var imageBytes = File.ReadAllBytes("bitmap.bmp");
            var image = imageBytes.ToImage();
            image.Save("output.bmp");
        }
