    public class RoofStyle
    {
        private RoofStyle() { }
        public string Display { get; private set; }
        public string Value { get; private set; }
        public readonly static RoofStyle Glass = new RoofStyle
        {
            Display = "Glass Top",  Value = "GTR",
        };
        public readonly static RoofStyle ConvertibleSoft = new RoofStyle
        {
            Display = "Convertible Soft Top", Value = "CST",
        };
        public readonly static RoofStyle HardTop = new RoofStyle
        {
            Display = "Hard Top", Value = "HT ",
        };
        public readonly static RoofStyle Targa = new RoofStyle
        {
            Display = "Targa Top", Value = "TT ",
        };
    }
