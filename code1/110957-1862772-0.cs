    class CookieConverter
    {
        private readonly Encoding _enc = Encoding.GetEncoding("iso-8859-1");
        public string PackCookieString(List<int> numbers)
        {
            MemoryStream memoryStream = new MemoryStream();
            foreach (int number in numbers)
            {
                byte[] bytes = GetVIntBytes(number);
                memoryStream.Write(bytes, 0, bytes.Length);
            }
            return _enc.GetString(memoryStream.ToArray());
        }
        public List<int> UnpackCookieString(string cookie)
        {
            byte[] bytes = _enc.GetBytes(cookie);
            List<int> numbers = new List<int>();
            int startIndex = 0;
            while (startIndex < bytes.Length)
            {
                numbers.Add(GetVInt(bytes, ref startIndex));
            }
            return numbers;
        }
        public byte[] GetVIntBytes(int value)
        {
            byte[] buffer = new byte[5];
            byte length = 0;
            while ((value & ~0x7F) != 0)
            {
                buffer[length] = (byte) ((value & 0x7f) | 0x80);
                value = value >> 7;
                length++;
            }
            buffer[length] = (byte) value;
            byte[] result = new byte[length+1];
            Array.Copy(buffer, 0, result, 0, result.Length);
            return result;
        }
        public int GetVInt(byte[] buffer, ref int startIndex)
        {
            byte b = buffer[startIndex];
            startIndex++;
            int i = b & 0x7F;
            for (int shift = 7; (b & 0x80) != 0; shift += 7)
            {
                b = buffer[startIndex];
                i |= (b & 0x7F) << shift;
                startIndex++;
            }
            return i;
        }
