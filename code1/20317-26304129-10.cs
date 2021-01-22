        public static byte[] HexadecimalStringToByteArray(string input)
        {
            var outputLength = input.Length / 2;
            var output = new byte[outputLength];
            var numeral = new char[2];
            using (var sr = new StringReader(input))
            {
                for (var i = 0; i < outputLength; i++)
                {
                    var read = sr.Read(numeral, 0, 2);
                    Debug.Assert(read == 2);
                    output[i] = Convert.ToByte(new string(numeral), 16);
                }
            }
            return output;
        }
