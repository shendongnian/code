    public sealed class StrongNameUtilities
    {
        public static byte[] GetPublicKeyToken(byte[] publicKey)
        {
            if (publicKey == null)
                throw new ArgumentNullException(nameof(publicKey));
            var blob = IntPtr.Zero;
            try
            {
                if (!StrongNameTokenFromPublicKey(publicKey, publicKey.Length, out blob, out var size))
                    throw new Win32Exception(StrongNameErrorInfo());
                var bytes = new byte[size];
                Marshal.Copy(blob, bytes, 0, size);
                return bytes;
            }
            finally
            {
                if (blob != IntPtr.Zero)
                {
                    StrongNameFreeBuffer(blob);
                }
            }
        }
        public static byte[] GetPublicKeyToken(string snkFile)
        {
            if (snkFile == null)
                throw new ArgumentNullException(nameof(snkFile));
            return GetPublicKeyToken(GetPublicKey(snkFile));
        }
        public static byte[] GetPublicKey(string snkFile)
        {
            if (snkFile == null)
                throw new ArgumentNullException(nameof(snkFile));
            var bytes = File.ReadAllBytes(snkFile);
            var blob = IntPtr.Zero;
            try
            {
                if (!StrongNameGetPublicKey(null, bytes, bytes.Length, out blob, out var size))
                    throw new Win32Exception(StrongNameErrorInfo());
                var pkBlob = new byte[size];
                Marshal.Copy(blob, pkBlob, 0, size);
                return pkBlob;
            }
            finally
            {
                if (blob != IntPtr.Zero)
                {
                    StrongNameFreeBuffer(blob);
                }
            }
        }
        public static void GenerateKeyFile(string snkFile, int keySizeInBits = 1024)
        {
            if (snkFile == null)
                throw new ArgumentNullException(nameof(snkFile));
            var bytes = GenerateKey(keySizeInBits);
            File.WriteAllBytes(snkFile, bytes);
        }
        public static byte[] GenerateKey(int keySizeInBits = 1024)
        {
            if (!StrongNameKeyGenEx(null, 0, keySizeInBits, out var blob, out var size))
                throw new Win32Exception(StrongNameErrorInfo());
            try
            {
                var bytes = new byte[size];
                Marshal.Copy(blob, bytes, 0, size);
                return bytes;
            }
            finally
            {
                if (blob != IntPtr.Zero)
                {
                    StrongNameFreeBuffer(blob);
                }
            }
        }
        [DllImport("mscoree")]
        private extern static void StrongNameFreeBuffer(IntPtr pbMemory);
        [DllImport("mscoree")]
        private static extern bool StrongNameGetPublicKey(
            [MarshalAs(UnmanagedType.LPWStr)] string szKeyContainer,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbKeyBlob,
            int cbKeyBlob,
            out IntPtr ppbPublicKeyBlob,
            [MarshalAs(UnmanagedType.U4)]out int pcbPublicKeyBlob);
        [DllImport("mscoree")]
        private static extern bool StrongNameTokenFromPublicKey(
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pbPublicKeyBlob,
            int cbPublicKeyBlob,
            out IntPtr ppbStrongNameToken,
            [MarshalAs(UnmanagedType.U4)]out int pcbStrongNameToken);
        [DllImport("mscoree", CharSet = CharSet.Unicode)]
        private static extern bool StrongNameKeyGenEx(string wszKeyContainer, int dwFlags, int dwKeySize, out IntPtr ppbKeyBlob, out int pcbKeyBlob);
        [DllImport("mscoree")]
        private static extern int StrongNameErrorInfo();
    }
