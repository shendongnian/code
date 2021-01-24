    public static X509Certificate2 GenerateCertificate(string subjectName)
    {
        var dn = new CX500DistinguishedName();
        dn.Encode("CN=" + subjectName, X500NameFlags.XCN_CERT_NAME_STR_COMMA_FLAG);
        //Create crytpo provider to generate an assymetric key
        int KeyType = (int)X509ProviderType.XCN_PROV_RSA_SCHANNEL;
        CspParameters cspParams = new CspParameters(KeyType);
        cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
        cspParams.KeyContainerName = Guid.NewGuid().ToString();
        var rsa = new RSACryptoServiceProvider(2048, cspParams);
        var CryptoProvider = rsa.CspKeyContainerInfo.ProviderName;
        var keyContainerName = rsa.CspKeyContainerInfo.KeyContainerName;
        CX509PrivateKey privateKey = new CX509PrivateKey();
        privateKey.MachineContext = true;
        privateKey.ProviderName = CryptoProvider;
        privateKey.ContainerName = keyContainerName;
        privateKey.KeyUsage = X509PrivateKeyUsageFlags.XCN_NCRYPT_ALLOW_ALL_USAGES;
        privateKey.Open();
        keyContainerName = privateKey.ContainerName;
        CX509PublicKey publicKey = privateKey.ExportPublicKey();
        var oid = new CObjectId();
        oid.InitializeFromValue("1.3.6.1.5.5.7.3.1"); // SSL server
        var oidlist = new CObjectIds();
        oidlist.Add(oid);
        var eku = new CX509ExtensionEnhancedKeyUsage();
        eku.InitializeEncode(oidlist);
        var hashobj = new CObjectId();
        hashobj.InitializeFromAlgorithmName(ObjectIdGroupId.XCN_CRYPT_HASH_ALG_OID_GROUP_ID,
            ObjectIdPublicKeyFlags.XCN_CRYPT_OID_INFO_PUBKEY_ANY,
            AlgorithmFlags.AlgorithmFlagsNone, "SHA256");
        CX509CertificateRequestCertificate certRequest = new CX509CertificateRequestCertificate();
        certRequest.InitializeFromPrivateKey(
            X509CertificateEnrollmentContext.ContextMachine,
            privateKey,
            "");
        certRequest.Subject = dn;
        certRequest.NotBefore = DateTime.Now;
        certRequest.NotAfter = DateTime.Now.AddYears(1);
        certRequest.HashAlgorithm = hashobj;
        certRequest.X509Extensions.Add((CX509Extension)eku);
        certRequest.Encode();
        return new X509Certificate2(
        Convert.FromBase64String(certRequest.RawData), "",
        X509KeyStorageFlags.Exportable)
        {
            PrivateKey = rsa,
            FriendlyName = subjectName
        };
    }
