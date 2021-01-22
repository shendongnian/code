    public sealed class RoofStyle : Enumeration<RoofStyle, int>
    {
        public static readonly RoofStyle Glass = new RoofStyle(0, "Glass Top", "GTR");
        public static readonly RoofStyle ConvertibleSoft = new RoofStyle(1, "Convertible Soft Top", "CST");
        public static readonly RoofStyle HardTop = new RoofStyle(2, "Hard Top", "HT ");
        public static readonly RoofStyle Targa = new RoofStyle(3, "Targa Top", "TT ");
        public static RoofStyle FromStringValue(string stringValue)
        {
            return AllValues.FirstOrDefault(value => value.StringValue == stringValue);
        }
        private RoofStyle(int id, string name, string stringValue) : base(id, name)
        {
            StringValue = stringValue;
        }
        public string StringValue { get; private set; }
    }
