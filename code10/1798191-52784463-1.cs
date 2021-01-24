     System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.InstalledUICulture;
                System.Globalization.NumberFormatInfo ni = (System.Globalization.NumberFormatInfo)ci.NumberFormat.Clone();
                ni.NumberDecimalSeparator = ".";
    
                string s = "-1.0";
                var result = float.Parse(s, ni);
