    void Main()
    {
        //0x05 = 101b
    	Console.WriteLine(IsBitSet(0x05, 0)); //True
    	Console.WriteLine(IsBitSet(0x05, 1)); //False
    	Console.WriteLine(IsBitSet(0x05, 2)); //True
    }
    bool IsBitSet(byte b, byte nPos){
    	return new BitArray(new[]{b})[nPos];
    }
