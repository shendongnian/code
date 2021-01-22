    Encoding targetEncoding = Encoding.GetEncoding(1252);
    // Encode a string into an array of bytes.
    Byte[] encodedBytes = targetEncoding.GetBytes(utfString);
    // Show the encoded byte values.
    Console.WriteLine("Encoded bytes: " + BitConverter.ToString(encodedBytes));
    // Decode the byte array back to a string.
    String decodedString = Encoding.Default.GetString(encodedBytes);
