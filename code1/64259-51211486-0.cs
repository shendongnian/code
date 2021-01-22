            public static byte[] String2ByteArray(string str)
            {
                char[] chars = str.ToArray();
                byte[] bytes = new byte[chars.Length * 2];
                for (int i = 0; i < chars.Length; i++)
                    Array.Copy(BitConverter.GetBytes(chars[i]), 0, bytes, i * 2, 2);
                return bytes;
            }
            public static string ByteArray2String(byte[] bytes)
            {
                char[] chars = new char[bytes.Length / 2];
                for (int i = 0; i < chars.Length; i++)
                    chars[i] = BitConverter.ToChar(bytes, i * 2);
                return new string(chars);
            }
