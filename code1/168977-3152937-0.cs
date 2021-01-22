    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    namespace Encryption
    {
    
    class AsymmetricED
    {
        private static RSAParameters param = new RSAParameters();
        /// <summary>
        /// Get Parameters
        /// </summary>
        /// <param name="pp">Export private parameters?</param>
        /// <returns></returns>
        public static RSAParameters GenerateKeys(bool pp)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            if (param.Equals(new RSAParameters()))
            {
                param = RSA.ExportParameters(true);
            }
            RSA.ImportParameters(param);
            return RSA.ExportParameters(pp);
        }
        static public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                //Create a new instance of RSACryptoServiceProvider.
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                //Import the RSA Key information. This only needs
                //toinclude the public key information.
                RSA.ImportParameters(RSAKeyInfo);
                //Encrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                return RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        static public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                //Create a new instance of RSACryptoServiceProvider.
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                //Import the RSA Key information. This needs
                //to include the private key information.
                RSA.ImportParameters(RSAKeyInfo);
                //Decrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                return RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                ConsoleColor col = Console.BackgroundColor;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(e.ToString());
                Console.BackgroundColor = col;
                return null;
            }
        }
    }
    }
