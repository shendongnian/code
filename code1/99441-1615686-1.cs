    using System;
    using System.Text;
    
    namespace ConvertExample
    {
       class ConvertExampleClass
       {
          static void Main()
          {
             string unicodeString = "This string contains the unicode character Pi(\u03a0)";
    
             // Create two different encodings.
             Encoding ascii = Encoding.ASCII;
             Encoding unicode = Encoding.Unicode;
    
             // Convert the string into a byte[].
             byte[] unicodeBytes = unicode.GetBytes(unicodeString);
    
             // Perform the conversion from one encoding to the other.
             byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);
                
             // Convert the new byte[] into a char[] and then into a string.
             // This is a slightly different approach to converting to illustrate
             // the use of GetCharCount/GetChars.
             char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
             ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
             string asciiString = new string(asciiChars);
    
             // Display the strings created before and after the conversion.
             Console.WriteLine("Original string: {0}", unicodeString);
             Console.WriteLine("Ascii converted string: {0}", asciiString);
          }
       }
    }
