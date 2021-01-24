    class Decor
    {
        public Size Size { get; set; }
        public string GetSize()
        {
            switch (Size.Units)
            {
                case UnitOfMeasure.Inches:
                    return string.Format("{0} x {1} x {2}",
                        Convert.ToFeetAndInches(Size.Width),
                        Convert.ToFeetAndInches(Size.Length),
                        Convert.ToFeetAndInches(Size.Height));
                case UnitOfMeasure.Feet:
                    return $"{Size.Width}' x {Size.Length}' x {Size.Height}'";
                case UnitOfMeasure.Centimeters:
                    return string.Format("{0} x {1} x {2}",
                        Convert.ToCentimetersAndMeters(Size.Width),
                        Convert.ToCentimetersAndMeters(Size.Length),
                        Convert.ToCentimetersAndMeters(Size.Height));
                case UnitOfMeasure.Meters:
                    return $"{Size.Width}m x {Size.Length}m x {Size.Height}m";
            }
            return $"{Size.Width} x {Size.Length} x {Size.Height}";
        }
    }
