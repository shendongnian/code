     public class Deskew
     {
            // Representation of a line in the image.  
            private class HougLine
            {
                // Count of points in the line.
                public int Count;
                // Index in Matrix.
                public int Index;
                // The line is represented as all x,y that solve y*cos(alpha)-x*sin(alpha)=d
                public double Alpha;
            }
    
    
            // The Bitmap
            Bitmap _internalBmp;
    
            // The range of angles to search for lines
            const double ALPHA_START = -20;
            const double ALPHA_STEP = 0.2;
            const int STEPS = 40 * 5;
            const double STEP = 1;
    
            // Precalculation of sin and cos.
            double[] _sinA;
            double[] _cosA;
    
            // Range of d
            double _min;
            
    
            int _count;
            // Count of points that fit in a line.
            int[] _hMatrix;
    
            public Bitmap DeskewImage(Bitmap image, int type, int binarizeThreshold)
            {
                Size oldSize = image.Size;
    
                _internalBmp = BitmapFunctions.Resize(image, new Size(1000, 1000), true, image.PixelFormat);
                Binarize(_internalBmp, binarizeThreshold);
    
    
                return Rotate(image, GetSkewAngle());
    		}
    
    		// Calculate the skew angle of the image cBmp.
            private double GetSkewAngle()
            {
                // Hough Transformation
                Calc();
    
                // Top 20 of the detected lines in the image.
                HougLine[] hl = GetTop(20);
    
                // Average angle of the lines
                double sum = 0;
                int count = 0;
                for (int i = 0; i <= 19; i++)
                {
                    sum += hl[i].Alpha;
                    count += 1;
                }
                return sum / count;
            }
    
            // Calculate the Count lines in the image with most points.
            private HougLine[] GetTop(int count)
            {
                HougLine[] hl = new HougLine[count];
    
                for (int i = 0; i <= count - 1; i++)
                {
                    hl[i] = new HougLine();
                }
                for (int i = 0; i <= _hMatrix.Length - 1; i++)
                {
                    if (_hMatrix[i] > hl[count - 1].Count)
                    {
                        hl[count - 1].Count = _hMatrix[i];
                        hl[count - 1].Index = i;
                        int j = count - 1;
                        while (j > 0 && hl[j].Count > hl[j - 1].Count)
                        {
                            HougLine tmp = hl[j];
                            hl[j] = hl[j - 1];
                            hl[j - 1] = tmp;
                            j -= 1;
                        }
                    }
                }
    
                for (int i = 0; i <= count - 1; i++)
                {
                    int dIndex = hl[i].Index / STEPS;
                    int alphaIndex = hl[i].Index - dIndex * STEPS;
                    hl[i].Alpha = GetAlpha(alphaIndex);
                    //hl[i].D = dIndex + _min;
                }
    
                return hl;
            }
    
    
            // Hough Transforamtion:
            private void Calc()
            {
                int hMin = _internalBmp.Height / 4;
                int hMax = _internalBmp.Height * 3 / 4;
    
                Init();
                for (int y = hMin; y <= hMax; y++)
                {
                    for (int x = 1; x <= _internalBmp.Width - 2; x++)
                    {
                        // Only lower edges are considered.
                        if (IsBlack(x, y))
                        {
                            if (!IsBlack(x, y + 1))
                            {
                                Calc(x, y);
                            }
                        }
                    }
                }
            }
    
            // Calculate all lines through the point (x,y).
            private void Calc(int x, int y)
            {
                int alpha;
    
                for (alpha = 0; alpha <= STEPS - 1; alpha++)
                {
                    double d = y * _cosA[alpha] - x * _sinA[alpha];
                    int calculatedIndex = (int)CalcDIndex(d);
                    int index = calculatedIndex * STEPS + alpha;
                    try
                    {
                        _hMatrix[index] += 1;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }
                }
            }
            private double CalcDIndex(double d)
            {
                return Convert.ToInt32(d - _min);
            }
            private bool IsBlack(int x, int y)
            {
                Color c = _internalBmp.GetPixel(x, y);
                double luminance = (c.R * 0.299) + (c.G * 0.587) + (c.B * 0.114);
                return luminance < 140;
            }
    
            private void Init()
            {
                // Precalculation of sin and cos.
                _cosA = new double[STEPS];
                _sinA = new double[STEPS];
    
                for (int i = 0; i < STEPS; i++)
                {
                    double angle = GetAlpha(i) * Math.PI / 180.0;
                    _sinA[i] = Math.Sin(angle);
                    _cosA[i] = Math.Cos(angle);
                }
    
                // Range of d:            
                _min = -_internalBmp.Width;
                _count = (int)(2 * (_internalBmp.Width + _internalBmp.Height) / STEP);
                _hMatrix = new int[_count * STEPS];
    
    
            }
    
            private static double GetAlpha(int index)
            {
                return ALPHA_START + index * ALPHA_STEP;
            }
    }
