     public void convertStrokestoImage()
        {
            StrokeCollection sc = strokes;
            byte[] inkData = null;
            using (MemoryStream inkMemStream = new MemoryStream())
            {
                sc.Save(inkMemStream);
                inkData = inkMemStream.ToArray();
            }
            byte[] gifData = null;
            using (Microsoft.Ink.Ink ink2 = new Microsoft.Ink.Ink())
            {
                ink2.Load(inkData);
                gifData = ink2.Save(Microsoft.Ink.PersistenceFormat.Gif);
            }
            MemoryStream ms = new MemoryStream(gifData);
            Image image = Image.FromStream(ms);
            image = resizeImage(image, 100, 150);
            image.Save("./Src/strokes.png");
        }
