     private SecKey GetKeyFromKeyChain()
        {
            var foundKey = SecKeyChain.QueryAsConcreteType(
                new SecRecord(SecKind.Key)
                {
                    ApplicationTag = KeyAlias
                }, out SecStatusCode errCode);
            if (foundKey == null || errCode != SecStatusCode.Success)
            {
                //Handle error
                return null;
            }
            return foundKey as SecKey;
        }
     public byte[] GetPublicKey()
        {
            NSError errCode = null;
            var foundKey = GetKeyFromKeyChain();
            var publicKey = foundKey?.GetPublicKey();
            var publicKeyExternalFormat = publicKey?.GetExternalRepresentation(out errCode);
            if (publicKeyExternalFormat == null || errCode != null)
            {
                //Handle error
                return null;
            }
            return publicKeyExternalFormat.ToArray();
        }
