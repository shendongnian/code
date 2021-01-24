    // Read the RSA private key:
    var p8Data = File.ReadAllBytes(@"resources\private.p8");    
    CngKey key = CngKey.Import(p8Data, CngKeyBlobFormat.Pkcs8PrivateBlob);
    var rsaprovider = new RSACng(key);
    // Process the enveloped CMS structure:
    var p7Data = File.ReadAllBytes(@"resources\p7\ID-4.p7");
    var envelopedCms = new System.Security.Cryptography.Pkcs.EnvelopedCms();
    envelopedCms.Decode(p7Data);
    var recipients = envelopedCms.RecipientInfos;
    var firstRecipient = recipients[0];
    
    // Decrypt the AES-256 CBC session key; take note of enforcing OAEP SHA-256:
    var result = rsaprovider.Decrypt(firstRecipient.EncryptedKey, RSAEncryptionPadding.OaepSHA256);
    // Build out the AES-256 CBC decryption:
    RijndaelManaged alg = new RijndaelManaged();
    alg.KeySize = 256;
    alg.BlockSize = 128;
    alg.Key = result;
    // I used an ASN.1 parser (https://lapo.it/asn1js/) to grab the AES IV from the PKCS#7 file.
    // I could not find an API call to get this from the enveloped CMS object:
    string hexstring = "919D287AAB62B672D6912E72D5DA29CD"; 
    var iv = StringToByteArray(hexstring);
    alg.IV = iv;
    alg.Mode = CipherMode.CBC;
    alg.Padding = PaddingMode.PKCS7;
 
    // Strangely both BouncyCastle as well as the Microsoft API report 406 bytes;
    // whereas https://lapo.it/asn1js/ reports only 400 bytes. 
    // The 406 bytes version results in an System.Security.Cryptography.CryptographicException 
    // with the message "Length of the data to decrypt is invalid.", so we strip it to 400 bytes:
    byte[] content = new byte[400];
    Array.Copy(envelopedCms.ContentInfo.Content, content, 400);
    string decrypted = null;
    ICryptoTransform decryptor = alg.CreateDecryptor(alg.Key, alg.IV);
    using (var memoryStream = new MemoryStream(content)) {
        using (var cryptoStream = new CryptoStream(memoryStream, alg.CreateDecryptor(alg.Key, alg.IV), CryptoStreamMode.Read)) {
            decrypted = new StreamReader(cryptoStream).ReadToEnd();
        }
    }
