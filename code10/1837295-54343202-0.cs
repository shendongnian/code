         private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(@"D:\shapes_Images\4.png");
            pictureBox1.Image = bitmap;
            image = bitmap ;
        }
        Bitmap image;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
           
            //Create a path and add lines.
            List<Point> outlinePoints = new List<Point>();
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] originalBytes = new byte[image.Width * image.Height * 4];
            Marshal.Copy(bitmapData.Scan0, originalBytes, 0, originalBytes.Length);
            //find non-transparent pixels visible from the top of the image
            for (int x = 0; x < bitmapData.Width; x++)
            {
                for (int y = 0; y < bitmapData.Height; y++)
                {
                    byte alpha = originalBytes[y * bitmapData.Stride + 4 * x + 3];
                    if (alpha != 0)
                    {
                        Point p = new Point(x, y);
                        if (!ContainsPoint(outlinePoints, p))
                            outlinePoints.Add(p);
                        break;
                    }
                }
            }
            //helper variable for storing position of the last pixel visible from both sides 
            //or last inserted pixel
            int? lastInsertedPosition = null;
            //find non-transparent pixels visible from the right side of the image
            for (int y = 0; y < bitmapData.Height; y++)
            {
                for (int x = bitmapData.Width - 1; x >= 0; x--)
                {
                    byte alpha = originalBytes[y * bitmapData.Stride + 4 * x + 3];
                    if (alpha != 0)
                    {
                        Point p = new Point(x, y);
                        if (!ContainsPoint(outlinePoints, p))
                        {
                            if (lastInsertedPosition.HasValue)
                            {
                                outlinePoints.Insert(lastInsertedPosition.Value + 1, p);
                                lastInsertedPosition += 1;
                            }
                            else
                            {
                                outlinePoints.Add(p);
                            }
                        }
                        else
                        {
                            //save last common pixel from visible from more than one sides
                            lastInsertedPosition = outlinePoints.IndexOf(p);
                        }
                        break;
                    }
                }
            }
            lastInsertedPosition = null;
            //find non-transparent pixels visible from the bottom of the image
            for (int x = bitmapData.Width - 1; x >= 0; x--)
            {
                for (int y = bitmapData.Height - 1; y >= 0; y--)
                {
                    byte alpha = originalBytes[y * bitmapData.Stride + 4 * x + 3];
                    if (alpha != 0)
                    {
                        Point p = new Point(x, y);
                        if (!ContainsPoint(outlinePoints, p))
                        {
                            if (lastInsertedPosition.HasValue)
                            {
                                outlinePoints.Insert(lastInsertedPosition.Value + 1, p);
                                lastInsertedPosition += 1;
                            }
                            else
                            {
                                outlinePoints.Add(p);
                            }
                        }
                        else
                        {
                            //save last common pixel from visible from more than one sides
                            lastInsertedPosition = outlinePoints.IndexOf(p);
                        }
                        break;
                    }
                }
            }
            lastInsertedPosition = null;
            //find non-transparent pixels visible from the left side of the image
            for (int y = bitmapData.Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < bitmapData.Width; x++)
                {
                    byte alpha = originalBytes[y * bitmapData.Stride + 4 * x + 3];
                    if (alpha != 0)
                    {
                        Point p = new Point(x, y);
                        if (!ContainsPoint(outlinePoints, p))
                        {
                            if (lastInsertedPosition.HasValue)
                            {
                                outlinePoints.Insert(lastInsertedPosition.Value + 1, p);
                                lastInsertedPosition += 1;
                            }
                            else
                            {
                                outlinePoints.Add(p);
                            }
                        }
                        else
                        {
                            //save last common pixel from visible from more than one sides
                            lastInsertedPosition = outlinePoints.IndexOf(p);
                        }
                        break;
                    }
                }
            }
            // Added to close the loop
            outlinePoints.Add(outlinePoints[0]);
            image.UnlockBits(bitmapData);
            GraphicsPath myPath = new GraphicsPath();
             
            myPath.AddLines(outlinePoints.ToArray());
           // return outlinePoints.ToArray();
            PathGradientBrush pthGrBrush = new PathGradientBrush(outlinePoints.ToArray());
            //foreach (Point p in outlinePoints.ToArray())
            //{
            //    //Point p1 = p;
            
            //}
            Color[] colors = { Color.Red , Color.Green  };
            pthGrBrush.SurroundColors = colors;
            pthGrBrush.CenterColor = Color.Red;   
            Blend blend = new Blend();
           // blend.Factors = new float[] { 1, 0 };
            blend.Positions = new float[] { 0, 0.25f };
            pthGrBrush.Blend = blend;
           // LinearGradientBrush linGrBrush = new LinearGradientBrush(new Point(0, 10),new Point(200, 10),Color.FromArgb(255, 255, 0, 0),Color.FromArgb(255, 0, 0, 255));  
            e.Graphics.FillPath(pthGrBrush, myPath);   
          //  Pen myPen = new Pen(Color.Black, 6);
           // e.Graphics.DrawPath(pthGrBrush, myPath);
           
        }
