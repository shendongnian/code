    public override int BlockSize
    {
        get { return _impl.BlockSize; }
        set
        {
            Debug.Assert(BlockSizeValue == 128);
            //Values which were legal in desktop RijndaelManaged but not here in this wrapper type
            if (value == 192 || value == 256)
                throw new PlatformNotSupportedException(SR.Cryptography_Rijndael_BlockSize);
            // Any other invalid block size will get the normal "invalid block size" exception.
            if (value != 128)
                throw new CryptographicException(SR.Cryptography_Rijndael_BlockSize);
        }
    }
