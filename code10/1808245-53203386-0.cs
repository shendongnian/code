    using (StringFormat string_format = new StringFormat())
            {
                SizeF stringSize = e.Graphics.MeasureString(text, _fontStyle);
                rect.Location = new PointF(Shape.center.X - (rect.Width / 2), Shape.center.Y - (rect.Height / 2));
                GraphicsContainer gc = e.Graphics.BeginContainer();
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                //e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(rect));
                RectangleF r = new RectangleF(rect.Location, rect.Size);
                GraphicsPath path = new GraphicsPath();
                if (text == "" || text == " ")
                    path.Dispose(); //Disposes the path to prevent OutOfMemoryExcetption
                else
                {
                    path.AddString(text, _fontStyle.FontFamily, Convert.ToInt32(_fontStyle.Style), _fontStyle.Height, new Point(0,0), string_format);
                    RectangleF text_rectf = path.GetBounds();
                    PointF[] target_pts = {
                                new PointF(r.Left, r.Top),
                                new PointF(r.Right, r.Top),
                                new PointF(r.Left, r.Bottom)};
                    using (Matrix m = new Matrix(text_rectf, target_pts)) 
                    using (Matrix rotate = new Matrix())
                    using (Matrix FlipXMatrix = new Matrix(-1, 0, 0, 1, 500, 0)) 
                    using (Matrix FlipYMatrix = new Matrix(1, 0, 0, -1, 0, 500))
                    using (Matrix TransformMatrix = new Matrix())
                    {
                        rotate.RotateAt(angle, new PointF(250,250));
                        TransformMatrix.Multiply(rotate);
                        if (flipped)
                            TransformMatrix.Multiply(FlipXMatrix);
                        TransformMatrix.Multiply(m);
                        path.Transform(TransformMatrix);
                        if (!isOutlined)
                            e.Graphics.FillPath(Brushes.Red, path);
                        else
                            e.Graphics.DrawPath(Pens.Red, path);
                    } 
                }
            e.Graphics.EndContainer(gc);
            }
