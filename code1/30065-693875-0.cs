    class Base64Encoder
    {
        public void Encode(string inFileName, string outFileName)
        {
            System.Security.Cryptography.ICryptoTransform transform = new System.Security.Cryptography.ToBase64Transform();
            using(System.IO.FileStream inFile = System.IO.File.OpenRead(inFileName),
                                      outFile = System.IO.File.Create(outFileName))
            using (System.Security.Cryptography.CryptoStream cryptStream = new System.Security.Cryptography.CryptoStream(outFile, transform, System.Security.Cryptography.CryptoStreamMode.Write))
            {
                // I'm going to use a 4k buffer, tune this as needed
                byte[] buffer = new byte[4096];
                int bytesRead;
                
                while ((bytesRead = inFile.Read(buffer, 0, buffer.Length)) > 0)
                    cryptStream.Write(buffer, 0, bytesRead);
                cryptStream.FlushFinalBlock();
            }
        }
        public void Decode(string inFileName, string outFileName)
        {
            System.Security.Cryptography.ICryptoTransform transform = new System.Security.Cryptography.FromBase64Transform();
            using (System.IO.FileStream inFile = System.IO.File.OpenRead(inFileName),
                                      outFile = System.IO.File.Create(outFileName))
            using (System.Security.Cryptography.CryptoStream cryptStream = new System.Security.Cryptography.CryptoStream(inFile, transform, System.Security.Cryptography.CryptoStreamMode.Read))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = cryptStream.Read(buffer, 0, buffer.Length)) > 0)
                    outFile.Write(buffer, 0, bytesRead);
                outFile.Flush();
            }
        }
        public void MemoryEncode(string inFileName, string outFileName)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(inFileName);
            System.IO.File.WriteAllText(outFileName, System.Convert.ToBase64String(bytes));
        }
    }
