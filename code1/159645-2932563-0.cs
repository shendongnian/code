    String myInput = "test1234";
    System.Security.Cryptography.SHA1 crypto = new System.Security.Cryptography.SHA1CryptoServiceProvider();
    Byte[] myInputBytes = Encoding.Default.GetBytes(myInput);
    Console.WriteLine(BitConverter.ToString(myInputBytes));
    Byte[] hash = crypto.ComputeHash(myInputBytes);
    Console.WriteLine(BitConverter.ToString(hash));
