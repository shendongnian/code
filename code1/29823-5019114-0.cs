      Matrix mRotate = new Matrix();
        mRotate.Translate(Convert.ToInt32(Width.Value) / -2, Convert.ToInt32(Height.Value) / -2, MatrixOrder.Append);
        mRotate.RotateAt(theta, new Point(0, 0), MatrixOrder.Append);
 
        using (GraphicsPath gp = new GraphicsPath())
        {  // transform image points by rotation matrix
            gp.AddPolygon(new Point[] { new Point(0, 0), new Point(Convert.ToInt32(Width.Value), 0), new Point(0, Convert.ToInt32(Height.Value)) });
            gp.Transform(mRotate);
            PointF[] pts = gp.PathPoints;
            // create destination bitmap sized to contain rotated source image
            Rectangle bbox = boundingBox(bmpSrc, mRotate);
            Bitmap bmpDest = new Bitmap(bbox.Width, bbox.Height);
            using (Graphics gDest = Graphics.FromImage(bmpDest))
            {  // draw source into dest
                Matrix mDest = new Matrix();
                mDest.Translate(bmpDest.Width / 2, bmpDest.Height / 2, MatrixOrder.Append);
                gDest.Transform = mDest;
                gDest.DrawImage(bmpSrc, pts);
                gDest.DrawRectangle(Pens.Transparent, bbox);
                //drawAxes(gDest, Color.Red, 0, 0, 1, 100, "");
                return bmpDest;
            }
        }
