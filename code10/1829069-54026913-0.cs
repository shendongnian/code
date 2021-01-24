    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    
    namespace LeftAlignment
    {
        class Program
        {
            static void ImprovedDrawString(Graphics graphics, string text, Font font, float x, float y)
            {
                // measure left padding
                StringFormat sf = new StringFormat(StringFormatFlags.NoClip);
                sf.SetMeasurableCharacterRanges(new CharacterRange[] { new CharacterRange(0, 1) });
                Region[] r = graphics.MeasureCharacterRanges(text, font, new RectangleF(0, 0, 1000, 100), sf);
                float leftPadding = r[0].GetBounds(graphics).Left;
    
                // draw string
                sf = new StringFormat(StringFormatFlags.NoClip);
                graphics.DrawString(text, font, Brushes.Black, x - leftPadding, y, sf);
            }
    
            static void Main(string[] args)
            {
                const int LeftMargin = 10;
                const string Text = "Cool water";
    
                // create off-screen bitmap
                using (Bitmap bitmap = new Bitmap(300, 100))
                {
                    // create graphics context
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        // enable high-quality output
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
    
                        // clear bitmap
                        graphics.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
    
                        // draw border and left margin
                        graphics.DrawRectangle(Pens.Gray, new Rectangle(0, 0, bitmap.Width - 1, bitmap.Height - 1));
                        graphics.DrawLine(Pens.Blue, LeftMargin, 8, LeftMargin, 92);
    
                        // draw string at 24 pt
                        Font font = new Font("Arial", 24);
                        ImprovedDrawString(graphics, Text, font, LeftMargin, 8);
    
                        // draw string at 36 pt
                        font = new Font("Arial", 36);
                        ImprovedDrawString(graphics, Text, font, LeftMargin, 44);
                    }
    
                    // save result as PNG
                    bitmap.Save("alignment.png", ImageFormat.Png);
                }
            }
        }
    }
