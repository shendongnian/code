    byte[] bytes = { 130, 200, 234, 23 }; // a byte array contains non-ASCII (or non-readable) characters
    string s1 = Encoding.UTF8.GetString(bytes); // ���
    byte[] decBytes1 = Encoding.UTF8.GetBytes(s1);  // decBytes1.Length == 10 !!
    // decBytes1 not same as bytes
    // using UTF8 or other Encoding object will get similar results
    string s2 = BitConverter.ToString(bytes);   // 82-C8-EA-17
    String[] tempAry = s2.Split('-');
    byte[] decBytes2 = new byte[tempAry.Length];
    for (int i = 0; i < tempAry.Length; i++)
        decBytes2[i] = Convert.ToByte(tempAry[i], 16);
    // decBytes2 same as bytes
    string s3 = Convert.ToBase64String(bytes);  // gsjqFw==
    byte[] decByte3 = Convert.FromBase64String(s3);
    // decByte3 same as bytes
    string s4 = HttpServerUtility.UrlTokenEncode(bytes);    // gsjqFw2
    byte[] decBytes4 = HttpServerUtility.UrlTokenDecode(s4);
    // decBytes4 same as bytes
