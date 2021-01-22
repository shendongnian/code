    public sealed class UmlautConverter
    {
        private Dictionary<char, string> converter = new Dictionary<char, string>()
        {
            {  'ä', "ae" },
            {  'Ä', "AE" },
            {  'ö', "oe" },
            {  'Ö', "OE" },
            {  'ü', "ue" },
            {  'Ü', "UE" },
            {  'ß', "ss" }
        };
        string value = null;
        public UmlautConverter(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                this.value = value;
            }
        }
        public string RemoveDiacritics()
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            string normalizedString = this.value.Normalize();
            foreach (KeyValuePair<char, string> item in this.converter)
            {
                string temp = normalizedString;
                normalizedString = temp.Replace(item.Key.ToString(), item.Value);
            }
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                normalizedString = normalizedString.Normalize(NormalizationForm.FormD);
                string c = normalizedString[i].ToString();
                if (CharUnicodeInfo.GetUnicodeCategory(Convert.ToChar(c)) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();
        }
        public bool HasUmlaut()
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            foreach (KeyValuePair<char, string> item in this.converter)
            {
                if (this.value.Contains(item.Key.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
    }
