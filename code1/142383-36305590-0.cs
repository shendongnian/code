    public static byte[] ToBitArray(bool[] byteArray)
    {
        return = byteArray
                   .Select(
                        (val1, idx1) => new { Index = idx1 / 8, Val = (byte)(val1 ? Math.Pow(2, idx1 % 8) : 0) }
                    )
                    .GroupBy(gb => gb.Index)
                    .Select(val2 => (byte)val2.Sum(t => (byte)t.Val))
                    .ToArray();
    }
