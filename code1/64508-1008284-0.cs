    public static class FormExtensions
    {
        public static void SaveAsImage(this Form form, string fileName, ImageFormat format)
        {
            var image = new Bitmap(form.Width, form.Height);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CopyFromScreen(form.Location, new Point(0, 0), form.Size);
            }
            image.Save(fileName, format);
        }
    }
