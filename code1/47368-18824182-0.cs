                    using (var gr = Graphics.FromImage(bmp))
                    {
                        try
                        {
                            var dest = new Rectangle(0, 0, bitmap.Width, h);
                            gr.DrawImage(image,dest , crop, GraphicsUnit.Point);
                            bmp.Save(tempfile,ImageFormat.Jpeg);
                            bmp.Dispose();
                        }
                        catch (Exception)
                        {
                            
                            
                        }
                        
                    }
