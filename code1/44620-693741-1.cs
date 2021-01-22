    public static unsafe byte GenerateCheckByte(byte[] packet, int length, UInt32 seed )
    {
        if (packet == null)
            throw new ArgumentNullException("packet"); // the right way in C#
        UInt32 checksum = 0xFFFFFFFF;
        length &= 0x7FFF;
        UInt32 moddedseed = seed << 8;
        for (int i = 0; i < length; i++)
            checksum = ( checksum >> 8 ) ^ Table.table[moddedseed + ( ( packet[i] ^ checksum ) & 0xFF )];
        byte result = (byte)(( (checksum>>24)&0xFF ) + ( (checksum>>8)&0xFF ) + ( (checksum>>16)&0xFF ) + ( checksum&0xFF ));
        return result;
    }
