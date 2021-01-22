        public static Image GetImage(string fileName)
        {
            Stream stream = GetResourceStream(fileName);
            Image image = null;
            if (stream != null)
            {
                image = Image.FromStream(stream);
            }
            return image;
        }
