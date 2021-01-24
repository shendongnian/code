    static class ColorExtensions
    {
        public static Color GetRandomRgb(this Color color)
        {
            var random = new Random();
            switch (random.Next(3))
            {
                case 1:
                    return Color.FromArgb(255, 0, 0);
                case 2:
                    return Color.FromArgb(0, 255, 0);
                default:
                    return Color.FromArgb(0, 0, 255);
            }
        }
    }
