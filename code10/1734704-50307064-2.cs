    public static class ColorExtensions
    {
        private static Color[] rgb = 
            {Color.FromArgb(0, 0, 255), Color.FromArgb(255, 255, 0), Color.FromArgb(0, 255, 0)};
        private static Random random = new Random();
        public static Color GetRandomRgb(this Color color)
        {
            return rgb[random.Next(rgb.Length)];
        }
    }
