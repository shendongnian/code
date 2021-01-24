        public static bool VerifySignature(byte[] hashBytes, byte[] signatureBytes)
        {
            PemReader pemReader = new PemReader(new StreamReader("PublicKey.pem"));
            RsaKeyParameters parameters = (RsaKeyParameters)pemReader.ReadObject();
            RsaDigestSigner signer = (RsaDigestSigner)SignerUtilities.GetSigner("SHA-256withRSA");
            signer.Init(false, parameters);
            signer.BlockUpdate(hashBytes, 0, hashBytes.Length);
            bool isValid = signer.VerifySignature(signatureBytes);
            return isValid;
        }
