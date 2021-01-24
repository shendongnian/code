    var hasCng = certificate.HasCngKey();
    if (hasCng)
    {
       privateKey = certificate.GetCngPrivateKey();
       Console.WriteLine("tiene CNG");
       var key = new Security.Cryptography.RSACng(privateKey);
       key.SignatureHashAlgorithm = CngAlgorithm.Sha1;
       var p = key.SignData(digest);
       return Convert.ToBase64String(p);
    }
