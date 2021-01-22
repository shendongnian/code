    public sealed class RoofStyle : IEquatable<RoofStyle>
    {
        public static readonly RoofStyle Glass = new RoofStyle(0, "Glass Top", "GTR");
        public static readonly RoofStyle ConvertibleSoft = new RoofStyle(1, "Convertible Soft Top", "CST");
        public static readonly RoofStyle HardTop = new RoofStyle(2, "Hard Top", "HT ");
        public static readonly RoofStyle Targa = new RoofStyle(3, "Targa Top", "TT ");
        public static IEnumerable<RoofStyle> AllStyles
        {
            get
            {
                yield return Glass;
                yield return ConvertibleSoft;
                yield return HardTop;
                yield return Targa;
            }
        }
        private RoofStyle(int id, string displayText, string stringValue)
        {
            Id = id;
            DisplayText = displayText;
            StringValue = stringValue;
        }
        public int Id { get; private set; }
        public string DisplayText { get; private set; }
        public string StringValue { get; private set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as RoofStyle);
        }
        public bool Equals(RoofStyle other)
        {
            return other != null && other.Id == Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
