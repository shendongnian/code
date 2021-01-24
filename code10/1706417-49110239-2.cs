    public class GridLengthConverter
    {
        public GridLength ConvertFromString(string s)
        {
            if (s == "auto")
                return GridLength.Auto;
            else if (s == "*")
                return new GridLength(1, GridUnitType.Star);
            else
            {
                int pixels;
                int.TryParse(s, out pixels);
                var g = new GridLength(pixels);
                return g;
            }
        }
    }
