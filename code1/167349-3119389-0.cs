    public static class Int32Extensions
    {
        public static Miles ToMiles( this Int32 distance )
        {
            return new Miles( distance );
        }
    }
    
    public class Miles
    {
        private Int32 _distance;
    
        public Miles( Int32 distance )
        {
            _distance = distance;
        }
    
        public Int32 Distance
        {
            get
            {
                return _distance;
            }
        }
    }
