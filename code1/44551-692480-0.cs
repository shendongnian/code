    public static void Func_X_2(byte[] stream, int key, byte keyByte)
    {
        stream[0] ^= (byte)(stream[0] + BitConverter.GetBytes(LoWord(key))[0]);
        stream[1] ^= (byte)(stream[1] + BitConverter.GetBytes(LoWord(key))[1]);
        stream[2] ^= (byte)(stream[2] + BitConverter.GetBytes(HiWord(key))[0]);
        stream[3] ^= (byte)(stream[3] + BitConverter.GetBytes(HiWord(key))[1]);
        stream[4] ^= (byte)(stream[4] + BitConverter.GetBytes(LoWord(key))[0]);
        stream[5] ^= (byte)(stream[5] + BitConverter.GetBytes(LoWord(key))[1]);
        stream[6] ^= (byte)(stream[6] + BitConverter.GetBytes(HiWord(key))[0]);
        stream[7] ^= (byte)(stream[7] + BitConverter.GetBytes(HiWord(key))[1]);
    }
    
    public static int LoWord(int dwValue)
    {
        return (dwValue & 0xFFFF);
    }
    
    public static int HiWord(int dwValue)
    {
        return (dwValue >> 16) & 0xFFFF;
    }
