    public static ulong MAC802DOT3(string macAddress)
    {
        string hex = macAddress.Replace(":", "");
        return Convert.ToUInt64(hex, 16);
    }
    // usage: var m = MAC802DOT3("14:10:9F:D4:04:1A");
    //            m becomes 22061633504282 (0x14109fd4041a)
