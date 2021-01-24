    var dnSigner = new CX500DistinguishedName();
    dnSigner.Encode("CN=" + signer.FriendlyName, X500NameFlags.XCN_CERT_NAME_STR_COMMA_FLAG);
    string base64Root = Convert.ToBase64String(signer.RawData);
    CSignerCertificate certSigner = new CSignerCertificate();
    bool useMachineStore = ((ICspAsymmetricAlgorithm)signer.PrivateKey).CspKeyContainerInfo.MachineKeyStore;
    certSigner.Initialize(useMachineStore, X509PrivateKeyVerify.VerifyNone, EncodingType.XCN_CRYPT_STRING_BASE64, base64Root);
    certRequest.SignerCertificate = certSigner;
    certRequest.Issuer = dnSigner;
