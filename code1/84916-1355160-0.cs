        var ip = String.Format("{0}.{1}.{2}.{3}",
        int.Parse(hexValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
        int.Parse(hexValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
        int.Parse(hexValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber),
        int.Parse(hexValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber));
