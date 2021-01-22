    public static Int32? TryParseInt32(this string str) {
        Int32 k;
        if(Int32.TryParse(str, out k))
            return k;
        return null;
    }
