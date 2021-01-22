    public static X509Certificate2 GetDigitalCertificate(string filename)
        {
            X509Certificate2 cert = null;
 
            int encodingType;
            int contentType;
            int formatType;
            IntPtr certStore = IntPtr.Zero;
            IntPtr cryptMsg = IntPtr.Zero;
            IntPtr context = IntPtr.Zero;
 
            if (!WinCrypt.CryptQueryObject(
                WinCrypt.CERT_QUERY_OBJECT_FILE,
                Marshal.StringToHGlobalUni(filename),
                (WinCrypt.CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED
                | WinCrypt.CERT_QUERY_CONTENT_FLAG_PKCS7_UNSIGNED
                | WinCrypt.CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED_EMBED), // <-- These are the attributes that makes it fast!!
                WinCrypt.CERT_QUERY_FORMAT_FLAG_ALL,
                0,
                out encodingType,
                out contentType,
                out formatType,
                ref certStore,
                ref cryptMsg,
                ref context))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
 
            // Get size of the encoded message.
            int cbData = 0;
            if (!WinCrypt.CryptMsgGetParam(
                cryptMsg,
                WinCrypt.CMSG_ENCODED_MESSAGE,
                0,
                IntPtr.Zero,
                ref cbData))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
 
            var vData = new byte[cbData];
 
            // Get the encoded message.
            if (!WinCrypt.CryptMsgGetParam(
                cryptMsg,
                WinCrypt.CMSG_ENCODED_MESSAGE,
                0,
                vData,
                ref cbData))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
 
            var signedCms = new SignedCms();
            signedCms.Decode(vData);
 
            if (signedCms.SignerInfos.Count > 0)
            {
                var signerInfo = signedCms.SignerInfos[0];
 
                if (signerInfo.Certificate != null)
                {
                    cert = signerInfo.Certificate;
                }
            }
 
            return cert;
        }
