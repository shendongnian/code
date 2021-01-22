            private static void EncryptData(String inName, String outName, byte[] desKey, byte[] desIV)
        {  
            //Create the file streams to handle the input and output files.
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
            FileStream foutclear = new FileStream(outName + ".clear", FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            //Create variables to help with read and write.
            byte[] bin = new byte[4096]; //This is intermediate storage for the encryption.
            long rdlen = 0;              //This is the total number of bytes written.
            long totlen = fin.Length;    //This is the total length of the input file.
            int len;                     //This is the number of bytes to be written at a time.
            System.Security.Cryptography.SymmetricAlgorithm des = SymmetricAlgorithm.Create("DES"); // Using DES      
            CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);
            Console.WriteLine("Encrypting...");
            //Read from the input file, then encrypt and write to the output file.
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 4096);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
                len = fin.Read(bin, 0, 4096);
                foutclear.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            encStream.Close();
            foutclear.Close();
            fout.Close();
            fin.Close();        
        }
