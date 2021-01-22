    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using Org.BouncyCastle.Asn1;
    byte[] signature = ReadFile("signature.bin");
    byte[] dataToVerify = ReadFile("data.bin");
    byte[] rawPublicKey = KeyResources.publickey; // My public key is in a resource
    var x509 = new X509Certificate2(rawPublicKey);
    var dsa = x509.PublicKey.Key as DSACryptoServiceProvider;
    // extract signature components from ASN1 formatted signature
    DSASignatureDeformatter DSADeformatter = new DSASignatureDeformatter(dsa);
    DSADeformatter.SetHashAlgorithm("SHA1");
    Asn1InputStream bIn = new Asn1InputStream(new MemoryStream(signature));
    DerSequence seq = bIn.ReadObject() as DerSequence;
    var r11 = seq[0].GetEncoded();
    var r21 = seq[1].GetEncoded();
    byte[] p1363 = new byte[40];
    Array.Copy(r11, r11.Length - 20, p1363, 0, 20);
    Array.Copy(r21, r21.Length - 20, p1363, 20, 20);
    // and finalyl we can verify
    if (!DSADeformatter.VerifySignature(new SHA1CryptoServiceProvider().ComputeHash(dataToVerify), p1363))
    {
        // Noo, mismatch!
    }
