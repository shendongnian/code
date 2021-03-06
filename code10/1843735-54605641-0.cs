    using (System.Security.Cryptography.Rijndael rijndael = System.Security.Cryptography.Rijndael.Create()) {
        rijndael.GenerateKey();
        rijndael.GenerateIV();
        rijndael.BlockSize = 256; // this is what makes it different from AES
        using (System.Security.Cryptography.ICryptoTransform transform = rijndael.CreateEncryptor()) {
            var fileToBeEncrypted = System.IO.File.ReadAllBytes("Path");
            transform.TransformFinalBlock(fileToBeEncrypted, 0, fileToBeEncrypted.Length);
        }
    }
