    // Convert hex number, which represents an RTF code-page escaped character, 
    // to the desired character (uses '85' from your example as a literal):
    var number = int.Parse("85", System.Globalization.NumberStyles.HexNumber);
    Debug.Assert(number <= byte.MaxValue);  
    
    byte[] bytes = new byte[1] { (byte)number };
    char[] chars = Encoding.GetEncoding(1252).GetString(bytes).ToCharArray();
    // or, use:
    // char[] chars = Encoding.Default.GetString(bytes).ToCharArray();  
    
    string result = new string(chars);
