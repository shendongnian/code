    int orig = 1337;
    byte[] origBytes = BitConverter.GetBytes(orig);
    string encoded = Convert.ToBase64String(origBytes);
    byte[] decoded = Convert.FromBase64String(encoded);
    int converted = BitConverter.ToInt32(decoded, 0);
    System.Diagnostics.Debug.Assert(orig == converted);
