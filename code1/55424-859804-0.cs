            public static Image GetImage(string fileName)
        {
            Stream stream = GetResourceStream(fileName);
            Image image = null;
            if (stream != null)
            {
                image = LoadImage(stream);
            }
            return image;
        }
