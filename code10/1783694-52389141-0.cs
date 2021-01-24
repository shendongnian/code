    byte[] dataBytes = ReadFirstSegment();
    byte[] signatureBytes = ReadSecondSegment();
    SignedCms cms = new SignedCms(new ContentInfo(dataBytes), detached: true);
    cms.Decode(signatureBytes);
    // This next line throws a CryptographicException if the signature can't be verified
    cms.CheckSignature(true);
    SignerInfoCollection signers = cms.SignerInfos;
    if (signers.Count != 1)
    {
        // probably fail
    }
    if (!IsExpectedCertificate(signers[0].Certificate))
    {
        // fail
    }
    // success
