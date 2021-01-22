    public static class MathUtil {
        /// <summary>
        /// smallest such that 1.0+EpsilonF != 1.0
        /// </summary>
        public const float EpsilonF = 1.192092896e-07F;
        /// <summary>
        /// smallest such that 1.0+EpsilonD != 1.0
        /// </summary>
        public const double EpsilonD = 2.2204460492503131e-016;
	    [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static bool IsZero( this double value ) {
            return Math.Abs( value ) < EpsilonD;
        }
	    [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static int Sign( this double value ) {
            if ( value < -EpsilonD ) {
                return -1;
            }
            if ( value > EpsilonD )
                return 1;
            return 0;
        }
