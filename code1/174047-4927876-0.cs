    public static bool IsTimestamped(string filename)
    {
        try
        {
            int encodingType;
            int contentType;
            int formatType;
            IntPtr certStore = IntPtr.Zero;
            IntPtr cryptMsg = IntPtr.Zero;
            IntPtr context = IntPtr.Zero;
            if (!WinCrypt.CryptQueryObject(
                WinCrypt.CERT_QUERY_OBJECT_FILE,
                Marshal.StringToHGlobalUni(filename),
                WinCrypt.CERT_QUERY_CONTENT_FLAG_ALL,
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
            //expecting contentType=10; CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED 
            //Logger.LogInfo(string.Format("Querying file '{0}':", filename));
            //Logger.LogInfo(string.Format("  Encoding Type: {0}", encodingType));
            //Logger.LogInfo(string.Format("  Content Type: {0}", contentType));
            //Logger.LogInfo(string.Format("  Format Type: {0}", formatType));
            //Logger.LogInfo(string.Format("  Cert Store: {0}", certStore.ToInt32()));
            //Logger.LogInfo(string.Format("  Crypt Msg: {0}", cryptMsg.ToInt32()));
            //Logger.LogInfo(string.Format("  Context: {0}", context.ToInt32()));
            // Get size of the encoded message.
            int cbData = 0;
            if (!WinCrypt.CryptMsgGetParam(
                cryptMsg,
                WinCrypt.CMSG_ENCODED_MESSAGE,//Crypt32.CMSG_SIGNER_INFO_PARAM,
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
                WinCrypt.CMSG_ENCODED_MESSAGE,//Crypt32.CMSG_SIGNER_INFO_PARAM,
                0,
                vData,
                ref cbData))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            var signedCms = new SignedCms();
            signedCms.Decode(vData);
            foreach (var signerInfo in signedCms.SignerInfos)
            {
                foreach (var unsignedAttribute in signerInfo.UnsignedAttributes)
                {
                    if (unsignedAttribute.Oid.Value == WinCrypt.szOID_RSA_counterSign)
                    {
                        //Note at this point we assume this counter signature is the timestamp
                        //refer to http://support.microsoft.com/kb/323809 for the origins
                        //TODO: extract timestamp value, if required
                        return true;
                    }
                }
            }
        }
        catch (Exception)
        {
            // no logging
        }
        return false;
    }
