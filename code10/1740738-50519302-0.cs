    using System;
    using System.Linq;
    public static string MAC802DOT3(ulong macAddress)
    {
        return string.Join(":",
                            BitConverter.GetBytes(macAddress).Reverse()
                            .Select(b => b.ToString("X2"))).Substring(6);
    }
    // usage: var s = MAC802DOT3(0x14109fd4041a);
    //        var s = MAC802DOT3(22061633504282);
    //            s becomes "14:10:9F:D4:04:1A"
