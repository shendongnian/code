    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.OpenSsl;
    using System.IO;
    using System.Security.Cryptography;
    // ...
    string pemKey = @"-----BEGIN EC PRIVATE KEY-----
    MHcCAQEEIKpAuZ/Wwp7FTSCNJ56fFM4Y/rf8ltXp3xnrooPxNc1UoAoGCCqGSM49
    AwEHoUQDQgAEqiRaEw3ItPsRAqdDjJCyqxhfm8y3tVrxLBAGhPM0pVhHuqmPoQFA
    zR5FA3IJZaWcopieEX5uZ4KMtDhLFu/FHw==
    -----END EC PRIVATE KEY-----";
    var keyPair = (AsymmetricCipherKeyPair)new PemReader(new StringReader(pemKey)).ReadObject();
    var pkcs8 = new Pkcs8Generator(keyPair.Private).Generate();
    var key = CngKey.Import(pkcs8.Content, CngKeyBlobFormat.Pkcs8PrivateBlob);
    var algorithm = new ECDsaCng(key);
    // Assign algorithm to certificate.PrivateKey, or perhaps use
    // ECDsaCertificateExtensions.CopyWithPrivateKey?
