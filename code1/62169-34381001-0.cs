        public static void DrawStringCenter(Image image, string s, Font font, Color color, RectangleF layoutRectangle)
        {
            var graphics = Graphics.FromImage(image);
            var brush = new SolidBrush(color);
            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            graphics.DrawString(s, font, brush, layoutRectangle, format);
        }
