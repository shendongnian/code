    int i;
    string s = "AF453d";
    bool isHex;
    isHex = int.TryParse(s, System.Globalization.NumberStyles.AllowHexSpecifier, null, out i);
    Console.WriteLine(isHex);
    Console.WriteLine(i);
