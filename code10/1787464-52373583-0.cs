    private Array2d<Complex> CustomFft( double sizeX, double sizeY, double n, double f0, double theta,
                                        double a ) {
        double halfX = sizeX / 2;
        double halfY = sizeY / 2;
        //pre-calculated values
        double rad1, rad2, b, f1cos, f1sin, f2cos, f2sin, cosrad1, sinrad1, cosrad2, sinrad2;
        rad1 = rad1 = ( Math.PI / 180 ) * ( 90 - theta );
        rad2 = rad1 + Math.PI;
        cosrad1 = Math.Cos( rad1 );
        sinrad1 = Math.Sin( rad1 );
        cosrad2 = Math.Cos( rad2 );
        sinrad2 = Math.Sin( rad2 );
        f1cos = f0 * Math.Cos( rad1 );
        f1sin = f0 * Math.Sin( rad1 );
        f2cos = f0 * Math.Cos( rad2 );
        f2sin = f0 * Math.Sin( rad2 );
        b = ( a / 5.0 ) / ( 2 * n );
        Array2d<Complex> kernel = new Array2d<Complex>((int)sizeX, (int)sizeY);
        for( double y = 0; y < sizeY; y++ ) {
            double v = y / sizeY;
            for( double x = 0; x < sizeX; x++ ) {
                double u = x / sizeX;
                double kw = Custom2( u, v, n, f0, theta, a, rad1, rad2, b, f1cos, f1sin, f2cos, f2sin,
                                     cosrad1, sinrad1 , cosrad2, sinrad2 );
                kernel[ (int)x, (int)y ] = new Complex( kw, 0 );
            }
        }
        return kernel;
    }
    private double Custom2( double u, double v, double n, double f0, double theta, double a,
                            double rad1, double rad2, double b, double f1cos, double f1sin, 
                            double f2cos, double f2sin, double cosrad1, double sinrad1,
                            double cosrad2, double sinrad2 ) {
            
        double ka = Basic2( u, v, n, f0, rad1, a, b, f1cos, f1sin, cosrad1, sinrad1 );
        double kb = Basic2( u, v, n, f0, rad2, a, b, f2cos, f2sin, cosrad2, sinrad2 );
        return Math.Max( ka, kb );
    }
    private double Basic2( double u, double v, double n, double f0, double rad, double a, double b,
                           double fcos, double fsin, double cosrad, double sinrad ) {
        double ua = u + fcos;
        double va = v + fsin;
        double ut = ua * cosrad + va * sinrad;
        double vt = ( -1 ) * ua * sinrad + va * cosrad;
        double p = ut / a;
        double q = vt / b;
        double sqrt = Math.Sqrt( p * p + q * q );
        return 1.0 / ( 1.0 + 0.414 * Math.Pow( sqrt, 2 * n ) );
    }
