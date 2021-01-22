    public struct Rational {
        private long[] Data;
        public long Numerator {
            get {
                try {
                    return this.Data[ 0 ];
                } catch( Exception ) {
                    this.Data = new long[ 2 ] { 0 , 1 };
                    return this.Data[ 0 ];
                }
            }
            set {
                try {
                    this.Data[ 0 ] = value;
                } catch( Exception ) {
                    this.Data = new long[ 2 ] { 0 , 1 };
                    this.Data[ 0 ] = value;
                }
            }
        }
        public long Denominator {
            get {
                try {
                    return this.Data[ 1 ];
                } catch( Exception ) {
                    this.Data = new long[ 2 ] { 0 , 1 };
                    return this.Data[ 1 ];
                }
            }
            set {
                try {
                    this.Data[ 1 ] = value;
                } catch( Exception ) {
                    this.Data = new long[ 2 ] { 0 , 1 };
                    this.Data[ 1 ] = value;
                }
            }
        }
        public Rational( long num , long denom ) {
            this.Data = new long[ 2 ] { num , denom };
            /* Todo: Find GCD etc. */
        }
        public Rational( long num ) {
            this.Data = new long[ 2 ] { num , 1 };
            this.Numerator = num;
            this.Denominator = 1;
        }
    }
