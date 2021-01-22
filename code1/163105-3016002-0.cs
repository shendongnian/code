    public static class Enums
    {
        private static Dictionary<string, RoofStyle> roofStyles =
            new Dictionary<string, RoofStyle>()
        {
            { "GTR", RoofStyle.Glass },
            { "CST", RoofStyle.ConvertibleSoft },
            { "HT ", RoofStyle.HardTop },
            { "TT ", RoofStyle.TargaTop }
        }
        public static RoofStyle GetRoofStyle(string code)
        {
            RoofStyle result;
            if (roofStyles.TryGetValue(code, out result))
                return result;
            throw new ArgumentException(...);
        }
