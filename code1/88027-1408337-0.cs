    class Program
    {
        class EncodedString
        {
            readonly byte[] _data;
            public readonly Encoding Encoding;
            public EncodedString(byte[] data, Encoding encoding)
            {
                _data = data;
                Encoding = encoding;
            }
            public static EncodedString FromString(string str, Encoding encoding)
            {
                return new EncodedString(encoding.GetBytes(str), encoding);
            }
            // Will make assumption about encoding - should be marked as explicit (in fact, I wouldn't recommend having this conversion at all!)
            public static explicit operator EncodedString(byte[] data)
            {
                return new EncodedString(data, Encoding.Default);
            }
            // Enough information for conversion - can make it implicit
            public static implicit operator byte[](EncodedString obj)
            {
                return obj._data;
            }
            // Strings in .Net are unicode so we make no assumptions here - implicit
            public static implicit operator EncodedString(string text)
            {
                var encoding = Encoding.Unicode;
                return new EncodedString(encoding.GetBytes(text), encoding);
            }
            // We have all the information for conversion here - implicit is OK
            public static implicit operator string(EncodedString obj)
            {
                return obj.Encoding.GetString(obj._data);
            }
        }
        static void Print(EncodedString format, params object[] args)
        {
            // Implicit conversion EncodedString --> string
            Console.WriteLine(format, args);
        }
        static void Main(string[] args)
        {
            // Text containing russian letters - needs care with Encoding!
            var text = "Привет, {0}!";
            // Implicit conversion string --> EncodedString
            Print(text, "world");
            // Create EncodedString from System.String but use UTF8 which takes 1 byte per char for simple English text
            var encodedStr = EncodedString.FromString(text, Encoding.UTF8);
            var fileName = Path.GetTempFileName();
            // Implicit conversion EncodedString --> byte[]
            File.WriteAllBytes(fileName, encodedStr);
            // Explicit conversion byte[] --> EncodedString
            // Prints *wrong* text because default encoding in conversion does not match actual encoding of the string
            // That's the reason I don't recommend to have this conversion!
            Print((EncodedString)File.ReadAllBytes(fileName), "StackOverflow.com");
            // Not a conversion at all. EncodingString is instantiated explicitly
            // Prints *correct* text because encoding is specified explicitly
            Print(new EncodedString(File.ReadAllBytes(fileName), Encoding.UTF8), "StackOverflow.com");
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
