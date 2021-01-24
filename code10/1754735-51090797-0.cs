    str = Uri.UnescapeDataString(str);
    byte[] signatureMessage = Convert.FromBase64String(str);
    ContentInfo content = new ContentInfo(yourDataHere);
    SignedCms signedCms = new SignedCms(content, detached: true);
    signedCms.Decode(signatureMessage);
    SignerInfoCollection signers = signedCms.SignerInfos;
    if (signers.Count != 1 || signers[0].Certificate != null)
    {
        // Reject it, this isn't what you're looking for.
        // At least, based on the sample you gave.
        //
        // You could, for Count == 1, accept Certificate == null or
        // Certificate.RawData.SequenceEqual(CurrentCer.RawData),
        // if you're so inclined.
    }
    // This throws if the signature doesn't check out.
    signedCms.CheckSignature(new X509Certificate2Collection(CurrentCer), verifySignatureOnly: true);
