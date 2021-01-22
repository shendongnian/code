    protected void Form1_Paint(object sender, PaintEventArgs e)
    {
        bool bold = false;
        bool italic = false;
    
        e.Graphics.PageUnit = GraphicsUnit.Point;
    
        using (SolidBrush b = new SolidBrush(Color.Black))
        {
            int y = 5;
    
            foreach (FontFamily fontFamily in pfc.Families)
            {
                if (fontFamily.IsStyleAvailable(FontStyle.Regular))
                {
                    using (Font font = new Font(fontFamily, 32, FontStyle.Regular))
                    {
                        e.Graphics.DrawString(font.Name, font, b, 5, y, StringFormat.GenericTypographic);
                    }
                    y += 40;
                }
                if (fontFamily.IsStyleAvailable(FontStyle.Bold))
                {
                    bold = true;
                    using (Font font = new Font(fontFamily, 32, FontStyle.Bold))
                    {
                        e.Graphics.DrawString(font.Name, font, b, 5, y, StringFormat.GenericTypographic);
                    }
                    y += 40;
                }
                if (fontFamily.IsStyleAvailable(FontStyle.Italic))
                {
                    italic = true;
                    using (Font font = new Font(fontFamily, 32, FontStyle.Italic))
                    {
                        e.Graphics.DrawString(font.Name, font, b, 5, y, StringFormat.GenericTypographic);
                    }
                    y += 40;
                }
            
                if(bold && italic)
                {
                    using(Font font = new Font(fontFamily, 32, FontStyle.Bold | FontStyle.Italic))
                    {
                        e.Graphics.DrawString(font.Name, font, b, 5, y, StringFormat.GenericTypographic);
                    }
                    y += 40;
                }
    
                using (Font font = new Font(fontFamily, 32, FontStyle.Underline))
                {
                    e.Graphics.DrawString(font.Name, font, b, 5, y, StringFormat.GenericTypographic);
                    y += 40;
                }
    
                using (Font font = new Font(fontFamily, 32, FontStyle.Strikeout))
                {
                    e.Graphics.DrawString(font.Name, font, b, 5, y, StringFormat.GenericTypographic);
                }
    
                b.Dispose();
    
            }
        }
    }
    
