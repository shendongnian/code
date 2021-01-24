    /// <summary>
    /// Illustrates the use of RijndaelSimple class to encrypt and decrypt data.
    /// </summary>
    public class RijndaelSimpleTest
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string  plainText       = "Hello, World!";    // original plaintext
    
            string  passPhrase      = "Kes0pr@se";        // can be any string
            string  saltValue       = "V@1tValue";        // can be any string
            string  hashAlgorithm   = "SHA1";             // can be "MD5"
            int     passwordIterations= 3;                // can be any number
            string  initVector      = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
            int     keySize         = 256;                // can be 192 or 128
    
            Console.WriteLine(String.Format("Plaintext : {0}", plainText));
    
            string cipherText = RijndaelSimple.Encrypt
            (
                plainText,
                passPhrase,
                saltValue,
                hashAlgorithm,
                passwordIterations,
                initVector,
                keySize
            );
    
            Console.WriteLine(String.Format("Encrypted : {0}", cipherText));
    
            plainText = RijndaelSimple.Decrypt
            (
                cipherText,
                passPhrase,
                saltValue,
                hashAlgorithm,
                passwordIterations,
                initVector,
                keySize
            );
    
            Console.WriteLine(String.Format("Decrypted : {0}", plainText));
        }
    }
    //
    // END OF FILE
