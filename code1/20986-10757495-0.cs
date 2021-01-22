    public static byte[] StrToByteArray(string str)
        {
            Dictionary<string, byte> hexindex = new Dictionary<string, byte>();
            for (byte i = 0; i < 255; i++)
                hexindex.Add(i.ToString("X2"), i);
            List<byte> hexres = new List<byte>();
            for (int i = 0; i < str.Length; i += 2)            
                hexres.Add(hexindex[str.Substring(i, 2)]);
            
            return hexres.ToArray();
        }
