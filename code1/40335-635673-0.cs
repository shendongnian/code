        public static class FormExtensions
        {
            public static void PrintForm(this Form f)
            {
                PrintDocument doc = new PrintDocument();
                doc.PrintPage += (o, e) =>
                {
                    Bitmap image = new Bitmap(f.ClientRectangle.Width, f.ClientRectangle.Height);
                    f.DrawToBitmap(image, f.ClientRectangle);
    
                    e.Graphics.DrawImage(image, e.PageBounds);
                };
    
                doc.Print();
            }
        }
