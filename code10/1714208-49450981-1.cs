        [System.Security.SecurityCritical]
        public AesCryptoServiceProvider () {
            Contract.Ensures(m_cspHandle != null && !m_cspHandle.IsInvalid && !m_cspHandle.IsClosed);
 
            // On Windows XP the AES CSP has the prototype name, but on newer operating systems it has the
            // standard name
            string providerName = CapiNative.ProviderNames.MicrosoftEnhancedRsaAes;
            if (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor == 1) {
                providerName = CapiNative.ProviderNames.MicrosoftEnhancedRsaAesPrototype;
            }
 
            m_cspHandle = CapiNative.AcquireCsp(null,
                                                providerName,
                                                CapiNative.ProviderType.RsaAes,
                                                CapiNative.CryptAcquireContextFlags.VerifyContext,
                                                true);
 
            // CAPI will not allow feedback sizes greater than 64 bits
            FeedbackSizeValue = 8;
 
            // Get the different AES key sizes supported by this platform, raising an error if there are no
            // supported key sizes.
            int defaultKeySize = 0;
            KeySizes[] keySizes = FindSupportedKeySizes(m_cspHandle, out defaultKeySize);
            if (keySizes.Length != 0) {
                Debug.Assert(defaultKeySize > 0, "defaultKeySize > 0");
                KeySizeValue = defaultKeySize;
            }
            else {
                throw new PlatformNotSupportedException(SR.GetString(SR.Cryptography_PlatformNotSupported));
            }
        }
        /// <summary>
        ///     Release any CAPI handles we're holding onto
        /// </summary>
        [System.Security.SecuritySafeCritical]
        protected override void Dispose(bool disposing) {
            Contract.Ensures(!disposing || m_key == null || m_key.IsClosed);
            Contract.Ensures(!disposing || m_cspHandle == null || m_cspHandle.IsClosed);
 
            try {
                if (disposing) {
                    if (m_key != null) {
                        m_key.Dispose();
                    }
 
                    if (m_cspHandle != null) {
                        m_cspHandle.Dispose();
                    }
                }
            }
            finally {
                base.Dispose(disposing);
            }
        }
