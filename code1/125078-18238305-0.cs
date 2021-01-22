        /// <summary>
        /// Rotates image in radian angle
        /// </summary>
        /// <param name="bmpSrc"></param>
        /// <param name="theta">in radian</param>
        /// <param name="extendedBitmapBackground">Because of rotation returned bitmap can have different boundaries from original bitmap. This color is used for filling extra space in bitmap</param>
        /// <returns></returns>
        public static Bitmap RotateImage(Bitmap bmpSrc, double theta, Color? extendedBitmapBackground = null)
        {
            theta = Convert.ToSingle(theta * 180 / Math.PI);
            Matrix mRotate = new Matrix();
            mRotate.Translate(bmpSrc.Width / -2, bmpSrc.Height / -2, MatrixOrder.Append);
            mRotate.RotateAt((float)theta, new Point(0, 0), MatrixOrder.Append);
            using (GraphicsPath gp = new GraphicsPath())
            {  // transform image points by rotation matrix
                gp.AddPolygon(new Point[] { new Point(0, 0), new Point(bmpSrc.Width, 0), new Point(0, bmpSrc.Height) });
                gp.Transform(mRotate);
                PointF[] pts = gp.PathPoints;
                // create destination bitmap sized to contain rotated source image
                Rectangle bbox = BoundingBox(bmpSrc, mRotate);
                Bitmap bmpDest = new Bitmap(bbox.Width, bbox.Height);
                
                using (Graphics gDest = Graphics.FromImage(bmpDest))
                {
                    if (extendedBitmapBackground != null)
                    {
                        gDest.Clear(extendedBitmapBackground.Value);
                    }
                    // draw source into dest
                    Matrix mDest = new Matrix();
                    mDest.Translate(bmpDest.Width / 2, bmpDest.Height / 2, MatrixOrder.Append);
                    gDest.Transform = mDest;
                    gDest.DrawImage(bmpSrc, pts);
                    return bmpDest;
                }
            }
        }
        private static Rectangle BoundingBox(Image img, Matrix matrix)
        {
            GraphicsUnit gu = new GraphicsUnit();
            Rectangle rImg = Rectangle.Round(img.GetBounds(ref gu));
            // Transform the four points of the image, to get the resized bounding box.
            Point topLeft = new Point(rImg.Left, rImg.Top);
            Point topRight = new Point(rImg.Right, rImg.Top);
            Point bottomRight = new Point(rImg.Right, rImg.Bottom);
            Point bottomLeft = new Point(rImg.Left, rImg.Bottom);
            Point[] points = new Point[] { topLeft, topRight, bottomRight, bottomLeft };
            GraphicsPath gp = new GraphicsPath(points, new byte[] { (byte)PathPointType.Start, (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line });
            gp.Transform(matrix);
            return Rectangle.Round(gp.GetBounds());
        }
