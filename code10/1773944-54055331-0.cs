    // Asymmetric key pair
    RsaKeyPairGenerator keyPairGenerator = new RsaKeyPairGenerator();
    keyPairGenerator.Init(
        new KeyGenerationParameters(
            new SecureRandom(new CryptoApiRandomGenerator()), 2048));
    AsymmetricCipherKeyPair keyPair = keyPairGenerator.GenerateKeyPair();
    // Create certificate
    X509V3CertificateGenerator generator = new X509V3CertificateGenerator();
    generator.SetSubjectDN("foo");
    generator.SetIssuerDN("foo");
    generator.SetSerialNumber(new BigInteger("12345").Abs());
    generator.SetNotBefore(DateTime.UtcNow);
    generator.SetNotAfter(DateTime.UtcNow + TimeSpan.FromYears(1));
    generator.SetPublicKey(keyPair.Public);
    BouncyCastleX509Certificate certificate =
        generator.Generate(
            new Asn1SignatureFactory("SHA1WithRSA", keyPair.Private));
    // Create PKCS12 certificate bytes.
    Pkcs12Store store = new Pkcs12Store();
    X509CertificateEntry certificateEntry = new X509CertificateEntry(certificate);
    string friendlyName = "Friendly Name";
    string password = "password";
    store.SetCertificateEntry(friendlyName, certificateEntry);
    store.SetKeyEntry(
        friendlyName,
        new AsymmetricKeyEntry(keyPair.Private),
        new X509CertificateEntry[] { certificateEntry });
    string pfxData;
    using (MemoryStream memoryStream = new MemoryStream(512))
    {
        store.Save(memoryStream, password.ToCharArray(), this.SecureRandom);
        pfxData = CryptographicBuffer.EncodeToBase64String(memoryStream.ToArray().AsBuffer());
    }
    // Add the certificate to the cert store
    await CertificateEnrollmentManager.ImportPfxDataAsync(
        pfxData,
        password,
        ExportOption.NotExportable,
        KeyProtectionLevel.NoConsent,
        InstallOptions.DeleteExpired,
        friendlyName);
    // Read the UWP cert from the cert store
    Certificate uwpCertificate =
        (await CertificateStores.FindAllAsync(
            new CertificateQuery { FriendlyName = friendlyName }))[0];
    // Create the UWP HTTP client.
    HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
    filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
    filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);
    filter.ClientCertificate = uwpCertificate;
    HttpClient httpClient = new HttpClient(filter);
    // Profit!
