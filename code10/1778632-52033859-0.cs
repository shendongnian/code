        private static string GenerateColor()
        {
            Random random = new Random();
            string color;
            do
            {
                color = $"#{random.Next(0x808080) & 0x7E7E7E:X6}";
            }
            while (IsAlmostBlack(color));
            return color;
        }
        private static bool IsAlmostBlack(string color)
        {
            // #XX0000
            int red = int.Parse(color.Substring(1, 2), NumberStyles.HexNumber);
            // #00XX00
            int green = int.Parse(color.Substring(3, 2), NumberStyles.HexNumber);
            // #0000XX
            int blue = int.Parse(color.Substring(5, 2), NumberStyles.HexNumber);
            // Checks if all values are under a certain value (here 50[decimal])
            return red < 0x32 && green < 0x32 && blue < 0x32;
        }
