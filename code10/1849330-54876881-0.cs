    public static class PixelSizeConverter
    {
        private static float _density = -1f;
        public static float Density
        {
            get
            {
                if (_density == -1)
                    _density = Resources.System.DisplayMetrics.Density;
                return _density;
            }
        }
    
        private static float _scaledDensity = -1f;
        public static float ScaledDensity
        {
            get
            {
                if (_scaledDensity == -1)
                    _scaledDensity = Resources.System.DisplayMetrics.ScaledDensity;
                return _scaledDensity;
            }
        }
    
        public static int DpToPx(float dp)
        {
            return (int) (dp * Density);
        }
        public static float PxToDp(float px)
        {
            return px / Density;
        }
        public static int SpToPx(float sp)
        {
            return (int) (sp * ScaledDensity);
        }
    
        public static float PxToSp(float px)
        {
            return px / ScaledDensity;
        }
    
    }
