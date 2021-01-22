    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    
    namespace RBCrypto
    {
        public interface AXInterface
        {
            void openKeyStore(string storeName, bool currentUser, bool readOnly);
            int getStoreSize();
            string getFriendlyName(int index, bool subjectNameIfEmpty);
        }
    
        [ClassInterface(ClassInterfaceType.AutoDual)]
        public class KeyStore :AXInterface
        {
            public void openKeyStore(string storeName, bool currentUser, bool readOnly)
            {
                if (keystoreInitialized)
                    throw new Exception("Key Store must be closed before re-initialization");
    
                try
                {
                    if (currentUser) //user wants to open store used by the current user
                        certificateStore = new X509Store(storeName, StoreLocation.CurrentUser);
                    else             //user wants to open store used by local machine
                        certificateStore = new X509Store(storeName, StoreLocation.LocalMachine);
    
                    if (readOnly)
                        certificateStore.Open(OpenFlags.ReadOnly);
                    else
                        certificateStore.Open(OpenFlags.ReadWrite);
    
                    allCertificates = certificateStore.Certificates;
    
                    if (allCertificates == null)
                    {
                        certificateStore.Close();
                        throw new NullReferenceException("Certificates could not be gathered");
                    }
    
                    keystoreInitialized = true;
                }
                catch (ArgumentException ae)
                {
                    throw ae;
                }
                catch (SecurityException se)
                {
                    throw se;
                }
                catch (CryptographicException ce)
                {
                    throw ce;
                }
                catch (NullReferenceException ne)
                {
                    throw ne;
                }
            }
    
            ....
       }
    }
