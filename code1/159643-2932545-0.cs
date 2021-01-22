    string myInput = "test1234";
    foreach (EncodingInfo ei in Encoding.GetEncodings())
    {
      byte[] bytes = ei.GetEncoding().GetBytes(myInput);
      foreach (byte b in bytes)
      {
        Console.Write("{0:x} ", b);
      }
      Console.WriteLine("\t\t{0}", ei.DisplayName);
    }
