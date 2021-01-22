    String str = "asdf éß";
    String str2 = "asdf gh";
    EncodingInfo[] info =  Encoding.GetEncodings();
    foreach (EncodingInfo enc in info)
    {
        System.Console.WriteLine(enc.Name + " - " 
          + enc.GetEncoding().GetByteCount(str)
          + enc.GetEncoding().GetByteCount(str2));
    }
