    static void Main()
        {
            string unicodeString = "\u0432\u043b\u0430\u0434\u043e\u043c <b>\u043f\u0443\u0442\u0438\u043c<\b> \u043d\u0430\u0447";
            // Create two different encodings.
            Encoding utf8 = Encoding.UTF8;
            Encoding unicode = Encoding.Unicode;
            // Convert the string into a byte[].
            byte[] unicodeBytes = unicode.GetBytes(unicodeString);
            // Perform the conversion from one encoding to the other.
            byte[] utf8Bytes = Encoding.Convert(unicode, utf8, unicodeBytes);
            // Convert the new byte[] into a char[] and then into a string.
            // This is a slightly different approach to converting to illustrate
            // the use of GetCharCount/GetChars.
            char[] asciiChars = new char[utf8.GetCharCount(utf8Bytes, 0, utf8Bytes.Length)];
            utf8.GetChars(utf8Bytes, 0, utf8Bytes.Length, asciiChars, 0);
            string asciiString = new string(asciiChars);
            // Display the strings created before and after the conversion.
            Console.WriteLine("Original string: {0}", unicodeString);
            Console.WriteLine("Ascii converted string: {0}", asciiString);
            Console.ReadKey();
        }
