        private static Color Normalize(Color color)
        {
            int g =  150*((color.R + color.G + color.B) / 3);
            if (g > 255)
                g = 255;
            return Color.FromArgb(255,g,g,g);
        }
