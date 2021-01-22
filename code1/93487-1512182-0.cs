    private static byte[] GetArray(string input)
        {
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < input.Length; i += 2)
            {
                string hex = input.Substring(i, 2);
                bytes.Add(Convert.ToByte(Convert.ToUInt32(hex, 16)));
            }
            return bytes.ToArray();
        }
        private static string GetString(byte[] input)
        {
            StringBuilder buffer = new StringBuilder(input.Length);
            foreach (byte b in input)
            {
                buffer.Append(b.ToString("x2"));
            }
            return buffer.ToString();
        }
