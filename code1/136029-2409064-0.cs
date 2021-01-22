    public void TestMethod1()
    {
        string asciibase = "Dutch has funny chars: a,e,u";
        string diacrits = "                       ' \" \"";
        var merged = DiacritMerger.Merge(asciibase, diacrits);
    }
    public class DiacritMerger
    {
        static readonly Dictionary<char, List<char>> _lookup = new Dictionary<char, List<char>>
                             {
                                 {'\'', new List<char> {'á', 'é', 'í', 'ó', 'ú', 'ý'}},
                                 {'"', new List<char> {'ä', 'ë', 'ï', 'ö', 'ü', 'ÿ'}}
                             };
        public static string Merge(string asciiBase, string diacrits)
        {
            var withDiacrits = new StringBuilder();
            for (int i = 0; i < asciiBase.Length; i++)
            {
                withDiacrits.Append(!char.IsWhiteSpace(diacrits[i]) ? DiacritVersion(diacrits[i], asciiBase[i]) : asciiBase[i]);
            }
            return withDiacrits.ToString();
        }
        private static char DiacritVersion(char diacrit, char character)
        {
            foreach (char diacritCharater in _lookup[diacrit])
            {
                if (RemoveDiacritics(diacritCharater) == character) return diacritCharater;
            }
            return character;
        }
        public static char RemoveDiacritics(char c)
        {
            string normalized = c.ToString().Normalize(NormalizationForm.FormD);
            c = normalized[0];
            return c;
        }
    }
