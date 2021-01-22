    public System.Drawing.Image Generate(string Text, int CodeSize)
            {
                int minSize = Cm2Pixel(2.5); // 100;
                if (CodeSize < minSize)
                    CodeSize = minSize;
                
                if (string.IsNullOrEmpty(Text))
                {
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(CodeSize, CodeSize);
    
                    using (System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(bmp))
                    {
    
                        gfx.Clear(System.Drawing.Color.Black);
                        using(System.Drawing.Font fnt = new System.Drawing.Font("Verdana", 12, System.Drawing.FontStyle.Bold))
                        {
                            double y = CodeSize / 2.0 - fnt.Size;
                            gfx.DrawString("No Data", fnt, System.Drawing.Brushes.White, 5, (int)y, System.Drawing.StringFormat.GenericTypographic);
                        } // End Using fnt
                        
                    } // End using gfx
    
                    return bmp;
                } // End if (string.IsNullOrEmpty(Text))
    
    ...[Generate QR-Code]
    return [Generated QR-Code]
    }
