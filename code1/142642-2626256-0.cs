    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography.X509Certificates;
    using System.ComponentModel;
    using System.Security.Cryptography;
    
    namespace LargeCMS
    {
        class Win32
        {
            #region "CONSTS"
    
            public const int X509_ASN_ENCODING = 0x00000001;
            public const int PKCS_7_ASN_ENCODING = 0x00010000;
            public const int CMSG_SIGNED = 2;
            public const int CMSG_DETACHED_FLAG = 0x00000004;
            public const int AT_KEYEXCHANGE = 1;
            public const int AT_SIGNATURE = 2;
            public const String szOID_OIWSEC_sha1 = "1.3.14.3.2.26";
            public const int CMSG_CTRL_VERIFY_SIGNATURE = 1;
            public const int CMSG_CERT_PARAM = 12;
            public const int CMSG_SIGNER_CERT_INFO_PARAM = 7;
            public const int CERT_STORE_PROV_MSG = 1;
            public const int CERT_CLOSE_STORE_FORCE_FLAG = 1;
    
            #endregion
    
            #region "STRUCTS"
    
            [StructLayout(LayoutKind.Sequential)]
            public struct CRYPT_ALGORITHM_IDENTIFIER
            {
                public String pszObjId;
                BLOB Parameters;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct CERT_ID
            {
                public int dwIdChoice;
                public BLOB IssuerSerialNumberOrKeyIdOrHashId;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct CMSG_SIGNER_ENCODE_INFO
            {
                public int cbSize;
                public IntPtr pCertInfo;
                public IntPtr hCryptProvOrhNCryptKey;
                public int dwKeySpec;
                public CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm;
                public IntPtr pvHashAuxInfo;
                public int cAuthAttr;
                public IntPtr rgAuthAttr;
                public int cUnauthAttr;
                public IntPtr rgUnauthAttr;
                public CERT_ID                    SignerId;
                public CRYPT_ALGORITHM_IDENTIFIER HashEncryptionAlgorithm;
                public IntPtr pvHashEncryptionAuxInfo;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct CERT_CONTEXT
            {
                public int dwCertEncodingType;
                public IntPtr pbCertEncoded;
                public int cbCertEncoded;
                public IntPtr pCertInfo;
                public IntPtr hCertStore;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct BLOB
            {
                public int cbData;
                public IntPtr pbData;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct CMSG_SIGNED_ENCODE_INFO
            {
                public int cbSize;
                public int cSigners;
                public IntPtr rgSigners;
                public int cCertEncoded;
                public IntPtr rgCertEncoded;
                public int cCrlEncoded;
                public IntPtr rgCrlEncoded;
                public int cAttrCertEncoded;
                public IntPtr rgAttrCertEncoded;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct CMSG_STREAM_INFO
            {
                public int cbContent;
                public StreamOutputCallbackDelegate pfnStreamOutput;
                public IntPtr pvArg;
            }
    
            #endregion
    
            #region "DELEGATES"
    
            public delegate Boolean StreamOutputCallbackDelegate(IntPtr pvArg, IntPtr pbData, int cbData, Boolean fFinal);
    
            #endregion
    
            #region "API"
    
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern Boolean CryptAcquireContext(
              ref IntPtr hProv,
              String pszContainer,
              String pszProvider,
              int dwProvType,
              int dwFlags
            );
    
            [DllImport("Crypt32.dll", SetLastError = true)]
            public static extern IntPtr CryptMsgOpenToEncode(
                int dwMsgEncodingType,
                int dwFlags,
                int dwMsgType,
                ref CMSG_SIGNED_ENCODE_INFO pvMsgEncodeInfo,
                String pszInnerContentObjID,
                ref CMSG_STREAM_INFO pStreamInfo
            );
    
            [DllImport("Crypt32.dll", SetLastError = true)]
            public static extern IntPtr CryptMsgOpenToDecode(
                int dwMsgEncodingType,
                int dwFlags,
                int dwMsgType,
                IntPtr hCryptProv,
                IntPtr pRecipientInfo,
                ref CMSG_STREAM_INFO pStreamInfo
            );
            
            [DllImport("Crypt32.dll", SetLastError = true)]
            public static extern Boolean CryptMsgClose(
                IntPtr hCryptMsg
            );
    
            [DllImport("Crypt32.dll", SetLastError = true)]
            public static extern Boolean CryptMsgUpdate(
                IntPtr hCryptMsg,
                Byte[] pbData,
                int cbData,
                Boolean fFinal
            );
    
            [DllImport("Crypt32.dll", SetLastError = true)]
            public static extern Boolean CryptMsgUpdate(
                IntPtr hCryptMsg,
                IntPtr pbData,
                int cbData,
                Boolean fFinal
            );
    
            [DllImport("Crypt32.dll", SetLastError = true)]
            public static extern Boolean CryptMsgGetParam(
                IntPtr hCryptMsg,
                int dwParamType,
                int dwIndex,
                IntPtr pvData,
                ref int pcbData
            );
    
            [DllImport("Crypt32.dll", SetLastError = true)]
            public static extern Boolean CryptMsgControl(
                IntPtr hCryptMsg,
                int dwFlags,
                int dwCtrlType,
                IntPtr pvCtrlPara
            );
    
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern Boolean CryptReleaseContext(
                IntPtr hProv,
                int dwFlags
            );
    
            [DllImport("Crypt32.dll", SetLastError = true)]
            public static extern IntPtr CertCreateCertificateContext(
                int dwCertEncodingType,
                IntPtr pbCertEncoded,
                int cbCertEncoded
            );
    
            [DllImport("Crypt32.dll", SetLastError = true)]
            public static extern Boolean CertFreeCertificateContext(
                IntPtr pCertContext
            );
    
            [DllImport("Crypt32.dll", SetLastError = true)]
            public static extern IntPtr CertOpenStore(
                int lpszStoreProvider,
                int dwMsgAndCertEncodingType,
                IntPtr hCryptProv,
                int dwFlags,
                IntPtr pvPara
            );
    
            [DllImport("Crypt32.dll", SetLastError = true)]
            public static extern IntPtr CertGetSubjectCertificateFromStore(
                IntPtr hCertStore,
                int dwCertEncodingType,
                IntPtr pCertId
            );
    
            [DllImport("Crypt32.dll", SetLastError = true)]
            public static extern IntPtr CertCloseStore(
                IntPtr hCertStore,
                int dwFlags
            );
    
            #endregion
        }
    }
