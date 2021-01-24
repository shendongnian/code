    using (System.IO.FileStream inputFs = new System.IO.FileStream("inputPath", System.IO.FileMode.Open))
    {
        using (System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(inputFs, rijndael.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Read)) {
            using (System.IO.FileStream outputFs = new System.IO.FileStream("outputPath", System.IO.FileMode.CreateNew)) {
                cs.CopyTo(outputFs);
            }
        }
    }
