    public class xaml_backend_variables
    {
        private static double _mm_per_package = 0;
        public static double Mm_Per_Package
        {
            get { return _mm_per_package; }
            set { _mm_per_package = value < 0 ? 0 : value; }
        }
        
        public xaml_backend_variables()
        {
        }
    }
