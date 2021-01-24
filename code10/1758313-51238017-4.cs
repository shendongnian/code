    public static class HexColorTranslator
    {
        private static Dictionary<string, string> _hex2Name;
        private static Dictionary<string, string> Hex2Name
        {
            get
            {
                if (_hex2Name == null)
                {
                    _hex2Name = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    foreach (KnownColor ce in typeof(KnownColor).GetEnumValues())
                    {
                        var name = ce.ToString();
                        var color = Color.FromKnownColor(ce);
                        var hex = HexConverter(color);
                        _hex2Name[hex] = name;
                    }
                }
                return _hex2Name;
            }
        }
        //https://stackoverflow.com/a/2395708/1155329
        private static String HexConverter(System.Drawing.Color c)
        {
            return c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        public static string GetKnownColorFromHex(string hex)
        {
            hex = hex.TrimStart('#');
            if (Hex2Name.TryGetValue(hex, out string result)) return result;
            return "???";
        }
    }
