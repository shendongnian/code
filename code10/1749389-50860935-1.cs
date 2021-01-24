    SignedCms signedCms = new SignedCms();
    signedCms.Decode(message);
    // Throws on failure
    signedCms.CheckSignature(true);
    SignerInfoCollection signers = signedCms.SignerInfos;
    if (signers.Count != 1 || signers[0].Certificate == null)
    {
        throw new InvalidOperationException("I don't know how to verify the signer trust");
    }
    // Exercise left to the reader
    if (!IsSignerTrustedForThisMessage(signers[0].Certificate))
    {
        throw new CryptographicException();
    }
    EnvelopedCms envelopedCms = new EnvelopedCms();
    envelopedCms.Decode(signedCms.ContentInfo.Content);
    // If you know the expected certificate(s) for decryption
    envelopedCms.Decrypt(candidateCertsWithPrivateKey);
    // (which will search certificate stores if it can't find a match)
    // otherwise `envelopedCms.Decrypt();` will -only- search the cert stores
    // It's only the decrypted content after the call to Decrypt, of course.
    byte[] decryptedMessage = envelopedCms.ContentInfo.Content;
