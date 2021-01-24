    private static string ToSubjectPublicKeyInfo(RSA rsa)
    {
        RSAParameters rsaParameters = rsa.ExportParameters(false);
        AsnWriter writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        writer.PushSequence();
        writer.WriteObjectIdentifier("1.2.840.113549.1.1.1");
        writer.WriteNull();
        writer.PopSequence();
        AsnWriter innerWriter = new AsnWriter(AsnEncodingRules.DER);
        innerWriter.PushSequence();
        WriteRSAParameter(innerWriter, rsaParameters.Modulus);
        WriteRSAParameter(innerWriter, rsaParameters.Exponent);
        innerWriter.PopSequence();
        writer.WriteBitString(innerWriter.Encode());
        writer.PopSequence();
        return MakePem(writer.Encode(), "PUBLIC KEY");
    }
