        static ulong RandomUInt64()
        {
            var rng = new RNGCryptoServiceProvider();
            var bytes = new byte[8];
            rng.GetBytes(bytes);
            return BitConverter.ToUInt64(bytes);
        }
