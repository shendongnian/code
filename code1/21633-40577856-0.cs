    public struct Point2D {
        public static Point2D NULL = new Point2D(-1,-1);
        private int[] Data;
        public int X {
            get {
                return this.Data[ 0 ];
            }
            set {
                try {
                    this.Data[ 0 ] = value;
                } catch( Exception ) {
                    this.Data = new int[ 2 ];
                } finally {
                    this.Data[ 0 ] = value;
                }
            }
        }
        public int Z {
            get {
                return this.Data[ 1 ];
            }
            set {
                try {
                    this.Data[ 1 ] = value;
                } catch( Exception ) {
                    this.Data = new int[ 2 ];
                } finally {
                    this.Data[ 1 ] = value;
                }
            }
        }
        public Point2D( int x , int z ) {
            this.Data = new int[ 2 ] { x , z };
        }
        public static Point2D operator +( Point2D A , Point2D B ) {
            return new Point2D( A.X + B.X , A.Z + B.Z );
        }
        public static Point2D operator -( Point2D A , Point2D B ) {
            return new Point2D( A.X - B.X , A.Z - B.Z );
        }
        public static Point2D operator *( Point2D A , int B ) {
            return new Point2D( B * A.X , B * A.Z );
        }
        public static Point2D operator *( int A , Point2D B ) {
            return new Point2D( A * B.Z , A * B.Z );
        }
        public override string ToString() {
            return string.Format( "({0},{1})" , this.X , this.Z );
        }
    }
