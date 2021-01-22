    public static string IncrementValue(string value) {
        if (string.IsNullOrEmpty(value) || value.Length != 3) {
            string msg = string.Format("Incorrect value ('{0}' is not between AAA and ZZZ)", value);
            throw new ApplicationException(msg);
        }
        if (value == "ZZZ") {
            return "AAA";
        }
        int thisValue = Parse( value );
        thisValue = (thisValue + 1) % 17576; // 26 * 26 * 26
        return Format( thisValue );
    }
    private static int Parse( string value )
    {
         int result = 0;
         foreach (var c in value)
         {
             result += ('Z' - c);  // might need to cast to int?
         }
         return result;
    }
    private static string[] Alphabet = new string[] { 'A', 'B', ... };
    private static string Format( int value )
    {
       int digit0 = value % 26;
       int digit1 = (value / 26) % 26;
       int digit2 = value / 676;
       return Alphabet[digit2] + Alphabet[digit1] + Alphabet[digit0];
    }
