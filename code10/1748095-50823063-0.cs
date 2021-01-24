    public static unsafe string ToBinaryHex(this decimal This)
    {
        byte* pb = (byte*)&This;
        var bytes = Enumerable.Range(0, 16).Select(i => (*(pb + i)).ToString("X2"));
        return string.Join("-", bytes);
    }
