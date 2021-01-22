    public static string ConvertUintToBitString(uint Number)
    {
        string _BitString = string.Empty;
        if (Number >= 2147483648)
        {
            _BitString += '1';
            Number = Number - 2147483648;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 1073741824)
        {
            _BitString += '1';
            Number = Number - 1073741824;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 536870912)
        {
            _BitString += '1';
            Number = Number - 536870912;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 268435456)
        {
            _BitString += '1';
            Number = Number - 268435456;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 134217728)
        {
            _BitString += '1';
            Number = Number - 134217728;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 67108864)
        {
            _BitString += '1';
            Number = Number - 67108864;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 33554432)
        {
            _BitString += '1';
            Number = Number - 33554432;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 16777216)
        {
            _BitString += '1';
            Number = Number - 16777216;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 8388608)
        {
            _BitString += '1';
            Number = Number - 8388608;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 4194304)
        {
            _BitString += '1';
            Number = Number - 4194304;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 2097152)
        {
            _BitString += '1';
            Number = Number - 2097152;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 1048576)
        {
            _BitString += '1';
            Number = Number - 1048576;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 524288)
        {
            _BitString += '1';
            Number = Number - 524288;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 262144)
        {
            _BitString += '1';
            Number = Number - 262144;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 131072)
        {
            _BitString += '1';
            Number = Number - 131072;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 65536)
        {
            _BitString += '1';
            Number = Number - 65536;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 32768)
        {
            _BitString += '1';
            Number = Number - 32768;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 16384)
        {
            _BitString += '1';
            Number = Number - 16384;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 8192)
        {
            _BitString += '1';
            Number = Number - 8192;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 4096)
        {
            _BitString += '1';
            Number = Number - 4096;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 2048)
        {
            _BitString += '1';
            Number = Number - 2048;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 1024)
        {
            _BitString += '1';
            Number = Number - 1024;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 512)
        {
            _BitString += '1';
            Number = Number - 512;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 256)
        {
            _BitString += '1';
            Number = Number - 256;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 128)
        {
            _BitString += '1';
            Number = Number - 128;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 64)
        {
            _BitString += '1';
            Number = Number - 64;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 32)
        {
            _BitString += '1';
            Number = Number - 32;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 16)
        {
            _BitString += '1';
            Number = Number - 16;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 8)
        {
            _BitString += '1';
            Number = Number - 8;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 4)
        {
            _BitString += '1';
            Number = Number - 4;
        }
        else
        {
            _BitString += '0';
        }
        if (Number >= 2)
        {
            _BitString += '1';
            Number = Number - 2;
        }
        else
        {
            _BitString += '0';
        }
        if (Number == 1)
        {
            _BitString += '1';
        }
        else
        {
            _BitString += '0';
        }
        return _BitString;
    }
