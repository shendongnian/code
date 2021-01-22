        public static class FormExtensions
        {
            public static void PrintForm(this Form f)
            {
                PrintDocument document = new PrintDocument();
                document.PrintPage += (o, e) =>
                {
                    Bitmap image = new Bitmap(f.Width, f.Height);
                    f.DrawToBitmap(image, e.PageBounds);
                    e.Graphics.DrawImage(image, new Point(0, 0));
                };
                document.Print();
            }
        }
