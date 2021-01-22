     public static string getFecha()
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-EC");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            // maldita sea!
            string strDate = culture.TextInfo.ToTitleCase(DateTime.Now.ToLongDateString());
            return strDate.Replace("De", "de");
        }
