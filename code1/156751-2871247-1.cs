        byte[] bytes = new byte[value.Length / 2];
        for (int i = 0; i < value.Length; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(value.Substring(i, 2), 16);
        }
    If you have `"0x"` at the beginning you should skip two bytes.
