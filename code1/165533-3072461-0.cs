            public static string ConvertToHex(string asciiString)
        {
            var hex = "";
            foreach (var c in asciiString)
            {
                int tmp = c;
                hex += String.Format("{0:x2}", Convert.ToUInt32(tmp.ToString()));
            }
            return hex;
        }
        public static string ConvertToString(string hex)
        {
            var stringValue = "";
            // While there's still something to convert in the hex string
            while (hex.Length > 0)
            {
                stringValue += Convert.ToChar(Convert.ToUInt32(hex.Substring(0, 2), 16)).ToString();
                // Remove from the hex object the converted value
                hex = hex.Substring(2, hex.Length - 2);
            }
            return stringValue;
        }
        static void Main(string[] args)
        {
            string hex = ConvertToHex("don.joe@gmail.com");
            Console.WriteLine(hex);
            Console.ReadLine();
            string stringValue =
            ConvertToString(hex);
            Console.WriteLine(stringValue);
            Console.ReadLine();
            
        }
