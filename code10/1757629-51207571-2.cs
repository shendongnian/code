    string str = "Hello world";
    // Space for terminating \0
    byte[] bytes = new byte[Encoding.Default.GetByteCount(str) + 1];
    Encoding.Default.GetBytes(str, 0, str.Length, bytes, 0);
    fixed (byte* b = bytes)
    {
        sbyte* b2 = (sbyte*)b;
        // Pass the string, like:
        mwc.func2_w(b2);
    }
