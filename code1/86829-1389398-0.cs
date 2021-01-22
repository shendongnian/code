    string hexString = "38320B00";
    // convert the first 6 characters to bytes and combine them into an int
    // we can ignore the final two characters because the DATE type is a
    // 3-byte integer - the most-significant-byte should always be zero
    int days = byte.Parse(hexString.Substring(0, 2), NumberStyles.HexNumber)
        | byte.Parse(hexString.Substring(2, 2), NumberStyles.HexNumber) << 8
        | byte.Parse(hexString.Substring(4, 2), NumberStyles.HexNumber) << 16;
    DateTime dt = new DateTime(1, 1, 1).AddDays(days);
    Console.WriteLine(dt);    // 12/12/2009 00:00:00
