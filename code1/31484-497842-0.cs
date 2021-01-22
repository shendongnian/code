    using System.Text;
    string inputString = GetInput();
    var encoder = ASCIIEncoding.GetEncoder();
    encoder.Fallback = new EncoderReplacementFallback(string.Empty);
    byte[] bAsciiString = encoder.GetBytes(inputString);
    // Do something with bytes...
    // can write to a file as is
    File.WriteAllBytes(FILE_NAME, bAsciiString);
    // or turn back into a "clean" string
    string cleanString = ASCIIEncoding.GetString(bAsciiString); 
    // since the offending bytes have been removed, can use default encoding as well
    Assert.AreEqual(cleanString, Default.GetString(bAsciiString));
   
