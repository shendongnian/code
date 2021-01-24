    byte[] keyX = new byte[key1.Length / 2];
    byte[] keyY = new byte[keyX.Length];
    Buffer.BlockCopy(key1, 1, keyX, 0, keyX.Length);
    Buffer.BlockCopy(key1, 1 + keyX.Length, keyY, 0, keyY.Length);
    ECParameters parameters = new ECParameters
    {
        Curve = ECCurve.NamedCurves.brainpoolP256r1,
        Q =
        {
            X = keyX,
            Y = keyY,
        },
    };
    byte[] derivedKey;
    using (ECDiffieHellman bob = ECDiffieHellman.Create(parameters))
    using (ECDiffieHellmanPublicKey bobPublic = bob.PublicKey)
    {
        derivedKey = alice.DeriveKeyFromHash(bobPublic, HashAlgorithmName.SHA256);
    }
