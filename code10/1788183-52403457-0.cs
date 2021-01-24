    int BLOCK_SIZE = 16;
            double[,] macierz = new double[16, 16];
            for (int v = 0; v < BLOCK_SIZE; ++v)
            {
                for (int u = 0; u < BLOCK_SIZE; ++u)
                {
                     double cu = (u == 0) ? 1.0 / Math.Sqrt(2) : 1.0;
                    double cv = (v == 0) ? 1.0 / Math.Sqrt(2) : 1.0;
                    double dctCoeff = 0;
                   
                    for (int y1 = 0; y1 < BLOCK_SIZE; ++y1)
                    {
                        for (int x1 = 0; x1 < BLOCK_SIZE; ++x1)
                        {
                            double uCosFactor = Math.Cos((2 * x1 + 1) * Math.PI * u / (2 * (double)BLOCK_SIZE));
                            double vCosFactor = Math.Cos((2 * y1 + 1) * Math.PI * v / (2 * (double)BLOCK_SIZE));
                            double pixel = bitmapaWy1.GetPixel((x1 + 284), (y1 + 313)).R;
                            
                            dctCoeff += pixel * uCosFactor * vCosFactor;
                            //dctCoeffAlpha += pixelalpha * uCosFactor * vCosFactor;
                           
                        }
                    }
                    
                    dctCoeff *= (2 / (double)BLOCK_SIZE) * cu * cv;
                    macierz[u, v] = dctCoeff;
                }
            }
