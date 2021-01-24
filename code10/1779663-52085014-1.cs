    private double Gabor(double u, double v, double u0, double v0, double a, double b)
    {
        double p = (-2) * Math.PI * Math.PI;
        double q = (u-u0)/a;
        double r = (v - v0)/b;
        return Math.Exp(p * (q*q + r*r));
    }
    public Array2d<Complex> GaborKernelFft(int sizeX, int sizeY, double u0, double v0, double a, double b)
    {
        double halfX = sizeX / 2;
        double halfY = sizeY / 2;
        Array2d<Complex> kernel = new Array2d<Complex>(sizeX, sizeY);
        for (double y = 0; y < sizeY; y++)
        {
            double v = y / sizeY;
            // v -= HalfY;  // whether this is necessary or not depends on your FFT
            for (double x = 0; x < sizeX; x++)
            {
                double u = x / sizeX;
                // u -= HalfX;  // whether this is necessary or not depends on your FFT
                double g = Gabor(u, v, u0, v0, a, b);
                kernel[(int)x, (int)y] = new Complex(g, 0);
            }
        }
        return kernel;
    }
