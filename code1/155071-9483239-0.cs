    // Load the CSR file
    var csr = new X509Request(BIO.File("C:/temp/test.csr", "r"));
    OR
    var csr = new X509Request(@"-----BEGIN CERTIFICATE REQUEST-----...");
    // Read CSR file properties
    Console.WriteLine(csr.PublicKey.GetRSA().PublicKeyAsPEM);
    Console.WriteLine(csr.Subject.SerialNumber);
    Console.WriteLine(csr.Subject.Organization);
    .
    .
    .
