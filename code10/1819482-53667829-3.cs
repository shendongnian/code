    var buffer = new byte[content.Length]; //at first its size is actual size+padding
    
    using (var rijAlg = new AesCng())
    {
        rijAlg.Key = Key;
        rijAlg.IV = IV;
    
        ICryptoTransform decryptor = rijAlg.CreateDecryptor();
    
        using (MemoryStream ms = new MemoryStream(content))
        {
            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            {
                var actualSize = cs.Read(buffer, 0, content.Length);
                //we write the decrypted content to the buffer, and get the actual size
                Array.Resize(ref buffer, actualSize);
                //then we resize the buffer to the actual size
            }
        }
    }
    return buffer;
     
