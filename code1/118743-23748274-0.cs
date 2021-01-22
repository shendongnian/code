        public static string ToReadableString(byte[] data)
        {
            int length = data.Length;
            var sb = new StringBuilder(length);
            for (int index = 0; index < length; ++index)
            {
                char ch = (char)data[index];
                sb.Append(Char.IsControl(ch) ? '.' : ch);
            }
            return sb.ToString();
        }
