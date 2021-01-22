     private string getAssemblyAsHex(string asmPath)
     {
        using (BinaryReader br = new BinaryReader(File.OpenRead(asmPath)))
        {
            byte[] buff = new byte[br.BaseStream.Length];
            br.Read(buff, 0, buff.Length - 1);
            return ByteArrayToString(buff);
        }
     }
        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
</pre>
