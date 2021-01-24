    Encoding enc = new UTF8Encoding(true, true);
    string value = "\u00C6 \u00D8 \u00C0 \u00C1 \u00C2";
    try
    {
        byte[] bytes = enc.GetBytes(value);
        foreach (var byt in bytes)
            Debug.Write(String.Format("{0:X2} ", byt));
        Debug.WriteLine("");
        string value2 = enc.GetString(bytes);
        Debug.WriteLine(value2);
    }
    catch (EncoderFallbackException e)
    {
        Debug.WriteLine("Unable to encode {0} at index {1}",
                            e.IsUnknownSurrogate() ?
                                String.Format("U+{0:X4} U+{1:X4}",
                                            Convert.ToUInt16(e.CharUnknownHigh),
                                            Convert.ToUInt16(e.CharUnknownLow)) :
                                String.Format("U+{0:X4}",
                                            Convert.ToUInt16(e.CharUnknown)),
                            e.Index);
    }
