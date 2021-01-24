    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Engines;    
    
    public void Test()
    {
        RsaEngine engine;
        AsymmetricKeyParameter key;
        bool forEncryption;
        int chunkPosition = 0;
        int i = 0;
        int blockSize;
        int chunkSize;
        List<byte> output = new List<byte>();
        byte[] byteMessageArray;
        // Initialize key variable with your public or private key
        // Initialize byteMessageArray with your message to be encrypted or decrypted
        // Set forEncryption variable value 
        engine = new RsaEngine();
        engine.Init(forEncryption, key);
        blockSize = engine.GetInputBlockSize();
        while ((chunkPosition < byteMessageArray.Length))
        {
            chunkSize = Math.Min(blockSize, byteMessageArray.Length - (i * blockSize));
            output.AddRange(engine.ProcessBlock(byteMessageArray, chunkPosition, chunkSize));
            chunkPosition = (chunkPosition + blockSize);
            i += 1;
        }
        
        //Now in output you have messagge encrypted or decrypted with your private or public key
    }
