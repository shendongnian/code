    public static Bitmap RotateImageN(Bitmap bitmap, float angle)
    {
        Matrix matrix = new Matrix();
        matrix.Translate(bitmap.Width / -2, bitmap.Height / -2, MatrixOrder.Append);
        matrix.RotateAt(angle, new System.Drawing.Point(0, 0), MatrixOrder.Append);
        using (GraphicsPath graphicsPath = new GraphicsPath())
        {
            graphicsPath.AddPolygon(new System.Drawing.Point[] { new System.Drawing.Point(0, 0), new System.Drawing.Point(bitmap.Width, 0), new System.Drawing.Point(0, bitmap.Height) });
            graphicsPath.Transform(matrix);
            System.Drawing.PointF[] points = graphicsPath.PathPoints;
    
            Rectangle rectangle = boundingBox(bitmap, matrix);
            Bitmap resultBitmap = new Bitmap(rectangle.Width, rectangle.Height);
    
            using (Graphics gDest = Graphics.FromImage(resultBitmap))
            {
                Matrix mDest = new Matrix();
                mDest.Translate(resultBitmap.Width / 2, resultBitmap.Height / 2, MatrixOrder.Append);
                gDest.Transform = mDest;
                gDest.DrawImage(bitmap, points);
                return resultBitmap;
            }
        }
    }
    
    private static Rectangle boundingBox(Image image, Matrix matrix)
    {
        GraphicsUnit graphicsUnit = new GraphicsUnit();
        Rectangle boundingRectangle = Rectangle.Round(image.GetBounds(ref graphicsUnit));
        Point topLeft = new Point(boundingRectangle.Left, boundingRectangle.Top);
        Point topRight = new Point(boundingRectangle.Right, boundingRectangle.Top);
        Point bottomRight = new Point(boundingRectangle.Right, boundingRectangle.Bottom);
        Point bottomLeft = new Point(boundingRectangle.Left, boundingRectangle.Bottom);
        Point[] points = new Point[] { topLeft, topRight, bottomRight, bottomLeft };
        GraphicsPath graphicsPath = new GraphicsPath(points, new byte[] { (byte)PathPointType.Start, (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line });
        graphicsPath.Transform(matrix);
        return Rectangle.Round(graphicsPath.GetBounds());
    }
