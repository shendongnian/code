    using System;
    using System.Drawing;
    using Emgu.CV;
    using Emgu.CV.Structure;
    // ============================================================================
    namespace CS1 {
    // ============================================================================
    class Test
    {
        static void Main()
        {
            Image<Bgr, byte> color = new Image<Bgr, byte>(2, 2);
            for (int r = 0; r < color.Rows; r++) {
                for (int c = 0; c < color.Cols; c++) {
                    int n = (c + r * color.Cols) * 3;
                    color[r, c] = new Bgr(n, n+1, n+2);
                }
            }
    
            Matrix<byte> matrix = new Matrix<byte>(color.Rows, color.Cols, color.NumberOfChannels);
    
            color.CopyTo(matrix);
    
            Bitmap b = matrix.Mat.Bitmap;
    
            matrix.CopyTo(color);
    
            b = color.Bitmap;
    
            b = color.ToBitmap();
        }
    }
    // ============================================================================
    } // namespace CS1
    // ============================================================================
