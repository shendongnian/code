        public static string ToTitleCase(this string mText)
        {
            if (mText == null) return mText;
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.TextInfo TextInfo = cultureInfo.TextInfo;
            // TextInfo.ToTitleCase only operates on the string if is all lower case, otherwise it returns the string unchanged.
            return TextInfo.ToTitleCase(mText.ToLower());
        }
