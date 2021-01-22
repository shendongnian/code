    // ellipse class
    public class EllipseParameters {
        public double a {get; set;} 
        public double b {get; set;} 
        public double f {get; set;}
    }
    public Ellipses { 
        public EllipseParameters WGS84 {get;set;}
        public EllipseParameters Airy1830 {get;set;}
        public EllipseParameters Airy1849 {get;set;}
    }
    Ellipses e = new Ellipses {
        WGS84 = new EllipseParameters { a = 6378137,     b= 6356752.3142, f = 1/298.257223563 },
        Airy1830 = new EllipseParameters { a= 6377563.396, b= 6356256.910,  f= 1/299.3249646   },
        Airy1849 = new EllipseParameters { a= 6377340.189, b= 6356034.447,  f= 1/299.3249646   }
    };
