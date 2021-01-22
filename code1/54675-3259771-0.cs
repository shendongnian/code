    using (Bitmap bmp = new Bitmap(someWidth, someHeight))
    {
        using (Graphics g = Graphics.FromImage(bmp))
        {
            // figure out where our text will go
            Point textPoint = new Point(someX, someY);
            Size textSize = g.MeasureString(someText, someFont).ToSize();
            Rectangle textRect = new Rectangle(textPoint, textSize);
            // fill that rect with white
            g.FillRectangle(Brushes.White, textRect);
            // draw the text
            g.DrawString(someText, someFont, Brushes.Black, textPoint);
            // set any pure white pixels back to transparent
            for (int x = textRect.Left; x <= textRect.Left + textRect.Width; x++)
            {
                for (int y = textRect.Top; y <= textRect.Top + textRect.Height; y++)
                {
                    Color c = bmp.GetPixel(x, y);
                    if (c.A == 255 && c.R == 255 && c.G == 255 && c.B == 255)
                    {
                        bmp.SetPixel(x, y, Color.Transparent);
                    }
                }
            }
        }
    }
