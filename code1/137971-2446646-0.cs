    internal static unsafe bool TryParseInt32(string s, NumberStyles style, NumberFormatInfo info, out int result)
    {
        byte* stackBuffer = stackalloc byte[1 * 0x72];
        NumberBuffer number = new NumberBuffer(stackBuffer);
        result = 0; // <== see here!
        if (!TryStringToNumber(s, style, ref number, info, false))
        {
            return false;
        }
        if ((style & NumberStyles.AllowHexSpecifier) != NumberStyles.None)
        {
            if (!HexNumberToInt32(ref number, ref result))
            {
                return false;
            }
        }
        else if (!NumberToInt32(ref number, ref result))
        {
            return false;
        }
        return true;
    }
