     public bool IsPDFHeader(string fileName)
        {
            byte[] buffer = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            //buffer = br.ReadBytes((int)numBytes);
            buffer = br.ReadBytes(5);
            var enc = new ASCIIEncoding();
            var header = enc.GetString(buffer);
            //%PDF−1.0
            // If you are loading it into a long, this is (0x04034b50).
            if (buffer[0] == 0x25 && buffer[1] == 0x50
                && buffer[2] == 0x44 && buffer[3] == 0x46)
            {
                return header.StartsWith("%PDF-");
            }
            return false;
        }
