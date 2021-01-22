    private const int kTiffTagLength = 12;
    private const int kHeaderSize = 2;
    private const int kMinimumTiffSize = 8;
    private const byte kIntelMark = 0x49;
    private const byte kMotorolaMark = 0x4d;
    private const ushort kTiffMagicNumber = 42;
    private bool IsTiff(Stream stm)
    {
        stm.Seek(0);
        if (stm.Length < kMinimumTiffSize)
            return false;
        byte[] header = new byte[kHeaderSize];
        stm.Read(header, 0, header.Length);
        if (header[0] != header[1] || (header[0] != kIntelMark && header[0] != kMotorolaMark))
            return false;
        bool isIntel = header[0] == kIntelMark;
        ushort magicNumber = ReadShort(stm, isIntel);
        if (magicNumber != kTiffMagicNumber)
            return false;
        return true;
    }
    private ushort ReadShort(Stream stm, bool isIntel)
    {
        byte[] b = new byte[2];
        _stm.Read(b, 0, b.Length);
        return ToShort(_isIntel, b[0], b[1]);
    }
    private static ushort ToShort(bool isIntel, byte b0, byte b1)
    {
        if (isIntel)
        {
            return (ushort)(((int)b1 << 8) | (int)b0);
        }
        else
        {
            return (ushort)(((int)b0 << 8) | (int)b1);
        }
    }
