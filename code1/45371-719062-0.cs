    public byte[] GetRC4SessionBlobFromKey(byte[] keyData, RSACryptoServiceProvider publicKey)        
    {              
      using(MemoryStream ms = new MemoryStream())              
      using(BinaryWriter w = new BinaryWriter(ms))            
      {                   
        w.Write((byte) 0x01); // SIMPLEBLOB                    
        w.Write((byte) 0x02); // Version 2                    
        w.Write((byte) 0x00); // Reserved                    
        w.Write((byte) 0x00); // Reserved                    
        w.Write(0x00006801);  // ALG_ID = RC4 for the encrypted key.                
        w.Write(0x0000a400);  // CALG_RSA_KEYX                    
        byte[] encryptedKey = publicKey.Encrypt(key.Key);
        byte[] reversedEncryptedKey = new byte[encryptedKey.Length];
        for(int i=0;i<encryptedKey.Length;i++){
          reversedEncryptedKey[i] = encryptedKey[encryptedKey.Length - 1 - i];
        }
        w.Write(reversedEncryptedKey); // encrypted key in LSB byte order
        w.Flush();                
    
        return ms.ToArray();              
      }        
    }
