    var rsaWrite = new RSACryptoServiceProvider();
    var publicParams = rsaWrite.ExportParameters(false); // Generate the public key.
    var testpublicParams = publicParams;
    string st = Convert.ToBase64String(publicParams.Modulus);
    testpublicParams.Modulus = Convert.FromBase64String(st);
    if (!publicParams.Modulus.SequenceEqual(testpublicParams.Modulus))
    {
         Console.WriteLine("The key has been changed.");
    }
    else
    {
         Console.WriteLine("The key has not been changed. :D");
     }
