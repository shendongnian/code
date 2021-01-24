    Matrix matrix = new Matrix();
    matrix.Translate(bitmap.Width / -2, bitmap.Height / -2, MatrixOrder.Append);
    matrix.RotateAt(angle, new System.Drawing.Point(0, 0), MatrixOrder.Append);
    
    matrix.Scale(2, 2, MatrixOrder.Append);
    
    using (GraphicsPath graphicsPath = new GraphicsPath())
