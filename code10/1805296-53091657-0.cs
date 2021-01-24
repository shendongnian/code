    class Program
    {
        static void Main(string[] args)
        {
            string input = "testaa";
            TestEncodeDecode("test");
            TestEncodeDecode("testa");
            TestEncodeDecode("testaa");
            Console.ReadLine();
        }
        private static void TestEncodeDecode(string input)
        {
            string encoded = Encode(input);
            Console.WriteLine($"Encoded: {encoded}");
            string htmlEncoded = WebUtility.UrlEncode(encoded);
            Console.WriteLine($"htmlEncoded: {htmlEncoded}");
            string decodedString = Decode(htmlEncoded);
            Console.WriteLine($"Decoded: {decodedString}");
            Console.WriteLine();
        }
        private static string Decode(string htmlEncoded)
        {
            try
            {
                byte[] decoded = Convert.FromBase64String(htmlEncoded);
                return Encoding.ASCII.GetString(decoded);
            }
            catch(Exception)
            {
                return "Decoding failed";
            }
        }
        private static string Encode(string input)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(input);
            using (var stream = new MemoryStream())
            {
                stream.Write(bytes);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
