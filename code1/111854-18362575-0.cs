           public static byte[] GetBytes(this string str)
            {
                byte[] bytes = new byte[str.Length * sizeof(char)];
                System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
                return bytes;
            }
    
            public static Stream ToStream(this string str)
            {
                Stream StringStream = new MemoryStream();
                StringStream.Read(str.GetBytes(), 0, str.Length);
                return StringStream;
            }
