        static public int ConvertColourToWindowsRGB(Color dotNetColour)
        {
            int winRGB = 0;
            // windows rgb values have byte order 0x00BBGGRR
            winRGB |= (int)dotNetColour.R;
            winRGB |= (int)dotNetColour.G << 8;
            winRGB |= (int)dotNetColour.B << 16;
            return winRGB;
        }
        static public Color ConvertWindowsRGBToColour(int windowsRGBColour)
        {
            int r = 0, g = 0, b = 0;
            // windows rgb values have byte order 0x00BBGGRR
            r = (windowsRGBColour & 0x000000FF);
            g = (windowsRGBColour & 0x0000FF00) >> 8;
            b = (windowsRGBColour & 0x00FF0000) >> 16;
            Color dotNetColour = Color.FromArgb(r, g, b);
            return dotNetColour;
        }
