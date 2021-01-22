        public static byte[] HexadecimalStringToByteArray(string input)
        {
            var outputLength = input.Length / 2;
            var output = new byte[outputLength];
            var numeral = new char[2];
            using (var sr = new StringReader(input))
            {
                for (var i = 0; i < outputLength; i++)
                {
                    numeral[0] = (char)sr.Read();
                    numeral[1] = (char)sr.Read();
                    output[i] = Convert.ToByte(new string(numeral), 16);
                }
            }
            return output;
        }
