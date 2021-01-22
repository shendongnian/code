    var bytes = new byte[40]; // byte size
    using (var crypto = new RNGCryptoServiceProvider())
      crypto.GetBytes(bytes);
    
    var base64 = Convert.ToBase64String(bytes);
    Console.WriteLine(base64);
    
