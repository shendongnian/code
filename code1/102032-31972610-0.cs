    Encoding enc = (Encoding)Encoding.GetEncoding("utf-8").Clone();
    enc.EncoderFallback = new EncoderReplacementFallback("");
    char[] chars = new char[1];
    byte[] bytes = new byte[16];
    using (StreamWriter sw = new StreamWriter(@"C:\utf-8.txt"))
    {
        for (int i = 0; i <= char.MaxValue; i++)
        {
            chars[0] = (char)i;
            int count = enc.GetBytes(chars, 0, 1, bytes, 0);
            if (count != 0)
            {
                sw.WriteLine(chars[0]);
            }
        }
    }
