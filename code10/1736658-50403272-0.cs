    string Barcode = "*"+txtCode.Text+"*";
                string price = txtPprice.Text;
                string pname = txtPname.Text;
    
                using (Bitmap bitmap = new Bitmap(350, 220))
                {
                    bitmap.SetResolution(240, 240);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        Font font = new Font("IDAutomationHC39M", 10, FontStyle.Regular, GraphicsUnit.Point);
    
                        graphics.Clear(Color.White);
                        StringFormat stringformat = new StringFormat(StringFormatFlags.NoWrap);
                        graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                        graphics.TextContrast = 10;
                        SolidBrush black = new SolidBrush(Color.Black);
                        SolidBrush white = new SolidBrush(Color.White);
                        PointF TextPosition = new PointF(45F, 10F);
                        SizeF TextSize = graphics.MeasureString(Barcode, font, TextPosition, stringformat);
                        PointF pointPrice = new PointF(90f, 125f);
                        Font newfont2 = new Font("Cambria", 8, FontStyle.Regular, GraphicsUnit.Point);
                        Font newfont3 = new Font("Arial Black", 10, FontStyle.Regular, GraphicsUnit.Point);
                        graphics.DrawString("" + pname + "", newfont3, black, pointPrice);
                        PointF pointPname = new PointF(200f, 170f);
                        graphics.DrawString("" + price + " L.E.", newfont3, black, pointPname);
                        PointF pointBcode = new PointF(35f, 170f);
                        graphics.DrawString("" + Barcode + "", newfont2, black, pointBcode);
                        if (TextSize.Width > bitmap.Width)
                        {
                            float ScaleFactor = (bitmap.Width - (TextPosition.X / 2)) / TextSize.Width;
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            graphics.ScaleTransform(ScaleFactor, ScaleFactor);
                        }
    
                        graphics.DrawString(Barcode, font, new SolidBrush(Color.Black), TextPosition, StringFormat.GenericTypographic);
    
                        bitmap.Save(@"barcode.png", ImageFormat.Png);
                        this.pictureBox1.Image = (Bitmap)bitmap.Clone();
                        font.Dispose();
                    }
                } 
