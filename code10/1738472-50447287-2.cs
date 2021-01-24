    public bool VerifyData(Stream data, byte[] signature) {
                if (data == null) {
                    throw new ArgumentNullException("data");
                }
                if (signature == null) {
                    throw new ArgumentNullException("signature");
                }
     
                using (BCryptHashAlgorithm hashAlgorithm = new BCryptHashAlgorithm(HashAlgorithm, BCryptNative.ProviderName.MicrosoftPrimitiveProvider)) {
                    hashAlgorithm.HashStream(data);
                    byte[] hashValue = hashAlgorithm.HashFinal();
     
                    return VerifyHash(hashValue, signature);
                }
            }
     
            [SecuritySafeCritical]
            public override bool VerifyHash(byte[] hash, byte[] signature) {
                if (hash == null) {
                    throw new ArgumentNullException("hash");
                }
                if (signature == null) {
                    throw new ArgumentNullException("signature");
                }
     
                // We need to get the raw key handle to verify the signature. Asserting here is safe since verifiation
                // is not a protected operation, and we do not expose the handle to the user code.
                new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Assert();
     
                // This looks odd, but Key.Handle is really a duplicate so we need to dispose it
                using (SafeNCryptKeyHandle keyHandle = Key.Handle) {
                    CodeAccessPermission.RevertAssert();
     
                    return NCryptNative.VerifySignature(keyHandle, hash, signature);
                }
            }
