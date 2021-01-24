    class Program
    {
        static void Main(string[] args)
        {
            using (ECDiffieHellman alice = ECDiffieHellman.Create(ECCurve.NamedCurves.brainpoolP256r1))
            {
                var alicePublicKey = Convert.ToBase64String(alice.PublicKey.ToByteArray());
                //send alicePublicKey
                var nodejsKey = ""; //NODEJS brainpoolP256r1 publickey  base64
                byte[] nodejsKeyBytes= Convert.FromBase64String(nodejsKey);
                
                var aliceKey = Convert.ToBase64String(getDeriveKey(nodejsKeyBytes,alice));
                byte[] encryptedMessage = null;
                byte[] iv = null;
                // Send(aliceKey, "Secret message", out encryptedMessage, out iv);
            }
        }
        static byte[] getDeriveKey(byte[] key1, ECDiffieHellman alice)
        {
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
                return derivedKey = alice.DeriveKeyFromHash(bobPublic, HashAlgorithmName.SHA256);
            }
        }
    }
