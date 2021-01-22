    string myInput = "test1234";
    foreach (EncodingInfo ei in Encoding.GetEncodings())
    {
      byte[] bytes = ei.GetEncoding().GetBytes(myInput);
      Console.WriteLine("{0}\t\t{1}", 
        BitConverter.ToString(bytes), ei.DisplayName);
    }
