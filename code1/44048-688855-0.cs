    public byte[] CryptExportKey(SymmetricAlgorithm key, RSA publicKey){
      using(MemoryStream ms = new MemoryStream())
      using(BinaryWriter w = new BinaryWriter(w)){
        w.Write((byte) 0x01); // SIMPLEBLOB
        w.Write((byte) 0x02); // Version 2
        w.Write((byte) 0x00); // Reserved
        w.Write((byte) 0x00); // Reserved
        if(key is Rijndael){
          w.Write(0x00006611);  // ALG_ID for the encrypted key.
        }else if (key is TripleDES && key.KeySizeValue == 192){
          w.Write(0x00006603);  // ALG_ID for the encrypted key.
        }else{
          throw new NotSupportedException("Look the value up on http://msdn.microsoft.com/en-us/library/aa375549%28VS.85%29.aspx");
        }
        w.Write(0x0000a400);  // CALG_RSA_KEYX
        w.Write(publicKey.Encrypt(key.Key)); // encrypted key
        w.Flush();
        return ms.ToArray();
      }
    }
