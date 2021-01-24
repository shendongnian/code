    string pemKey = @"-----BEGIN EC PRIVATE KEY-----
    MHcCAQEEIKpAuZ/Wwp7FTSCNJ56fFM4Y/rf8ltXp3xnrooPxNc1UoAoGCCqGSM49
    AwEHoUQDQgAEqiRaEw3ItPsRAqdDjJCyqxhfm8y3tVrxLBAGhPM0pVhHuqmPoQFA
    zR5FA3IJZaWcopieEX5uZ4KMtDhLFu/FHw==
    -----END EC PRIVATE KEY-----";
    string pemCert = @"-----BEGIN CERTIFICATE-----
    ...
    -----END CERTIFICATE-----";
    var keyPair = (AsymmetricCipherKeyPair)new PemReader(new StringReader(pemKey)).ReadObject();
    var cert = (Org.BouncyCastle.X509.X509Certificate)new PemReader(new StringReader(pemCert)).ReadObject();
    var builder = new Pkcs12StoreBuilder();
    builder.SetUseDerEncoding(true);
    var store = builder.Build();
    var certEntry = new X509CertificateEntry(cert);
    store.SetCertificateEntry("", certEntry);
    store.SetKeyEntry("", new AsymmetricKeyEntry(keyPair.Private), new[] { certEntry });
    byte[] data;
    using (var ms = new MemoryStream())
    {
        store.Save(ms, Array.Empty<char>(), new SecureRandom());
        data = ms.ToArray();
    }
    var x509Cert = new X509Certificate2(data);
