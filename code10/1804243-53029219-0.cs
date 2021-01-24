        public static string CSharpMethod(string str)
        {            
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            var validAsciiCharecters = new List<int> { 200, 202, 216, 217, 218, 219, 221, 222, 223, 225, 227, 228, 230 };
            for (int i = 203; i <= 214; i++)
            {
                validAsciiCharecters.Add(i);
            }
            var win1256Bytes = Encoding.GetEncoding(1256).GetBytes(str);
            var newBytes = new List<byte>();
            foreach (var b in win1256Bytes)
            {
                if (validAsciiCharecters.Contains((int)b))
                {
                    newBytes.Add(b);
                }
            }
            return Encoding.GetEncoding(1256).GetString(newBytes.ToArray());
        }
