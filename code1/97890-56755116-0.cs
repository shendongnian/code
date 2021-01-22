csharp
        public static string Utf8Encode(string inputDate)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(inputDate);
            return Encoding.GetEncoding("iso-8859-1").GetString(bytes,0, bytes.Length);
        }
        public static string Utf8Decode(string inputDate)
        {
            byte[] bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(inputDate);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
