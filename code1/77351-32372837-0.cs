    public static string LimitByteLength3(string input, Int32 maxLenth)
        {
            string result = input;
            int byteCount = Encoding.UTF8.GetByteCount(input);
            if (byteCount > maxLenth)
            {
                var byteArray = Encoding.UTF8.GetBytes(input);
                result = Encoding.UTF8.GetString(byteArray, 0, maxLenth);
            }
            return result;
        }
