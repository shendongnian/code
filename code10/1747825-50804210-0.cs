    private static void PBKDF2(
        string password,
        byte[] salt,
        int iterationCount,
        string hashName,
        byte[] output)
    {
        int status = SafeNativeMethods.BCryptOpenAlgorithmProvider(
            out SafeNativeMethods.SafeBCryptAlgorithmHandle hPrf,
            hashName,
            null,
            SafeNativeMethods.BCRYPT_ALG_HANDLE_HMAC_FLAG);
        using (hPrf)
        {
            if (status != 0)
            {
                throw new CryptographicException(status);
            }
            byte[] passBytes = Encoding.UTF8.GetBytes(password);
            status = SafeNativeMethods.BCryptDeriveKeyPBKDF2(
                hPrf,
                passBytes,
                passBytes.Length,
                salt,
                salt.Length,
                iterationCount,
                output,
                output.Length,
                0);
            if (status != 0)
            {
                throw new CryptographicException(status);
            }
        }
    }
    [SuppressUnmanagedCodeSecurity]
    private static class SafeNativeMethods
    {
        private const string BCrypt = "bcrypt.dll";
        internal const int BCRYPT_ALG_HANDLE_HMAC_FLAG = 0x00000008;
        [DllImport(BCrypt, CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int BCryptDeriveKeyPBKDF2(
            SafeBCryptAlgorithmHandle hPrf,
            byte[] pbPassword,
            int cbPassword,
            byte[] pbSalt,
            int cbSalt,
            long cIterations,
            byte[] derivedKey,
            int cbDerivedKey,
            int dwFlags);
        [DllImport(BCrypt)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern int BCryptCloseAlgorithmProvider(IntPtr hAlgorithm, int flags);
        [DllImport(BCrypt, CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        internal static extern int BCryptOpenAlgorithmProvider(
            out SafeBCryptAlgorithmHandle phAlgorithm,
            string pszAlgId,
            string pszImplementation,
            int dwFlags);
        internal sealed class SafeBCryptAlgorithmHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            public SafeBCryptAlgorithmHandle() : base(true)
            {
            }
            protected override bool ReleaseHandle()
            {
                return BCryptCloseAlgorithmProvider(handle, 0) == 0;
            }
        }
    }
