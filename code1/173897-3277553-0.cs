    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.IO;
    class RijndaelSample
    {
        const String CryptFile = "Crypt.dat";
        const String IVFile = "IV.dat";
        static void Main()
        {
            try
            {
                // Create a new Rijndael object to generate a key
                // and initialization vector (IV).
                Rijndael RijndaelAlg = Rijndael.Create();
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                string privateKey = "qwertyuiopasdfghjklzxcvbnmqwerty";
                RijndaelAlg.Key = encoding.GetBytes(privateKey);
                bool cryptFileExists = File.Exists(CryptFile);
                bool ivFileExists = File.Exists(IVFile);
                if (cryptFileExists && ivFileExists)
                {
                    Console.WriteLine("Enter Text to Encrypt, or a Blank Line to Decrypt Previous:");
                }
                else
                {
                    Console.WriteLine("Enter Text to Encrypt:");
                }
                // Create a string to encrypt.
                string sData = Console.ReadLine();
                if (!String.IsNullOrEmpty(sData))
                {
                    // Initialize the IV explicitly to something random
                    RijndaelAlg.GenerateIV();
                    // Encrypt text to a file using the file name, key, and IV.
                    EncryptTextToFile(sData, CryptFile, RijndaelAlg);
                    // Save the IV for use when decrypting
                    File.WriteAllBytes(IVFile, RijndaelAlg.IV);
                }
                else if (!cryptFileExists || !ivFileExists)
                {
                    throw new InvalidOperationException("Previous Encrypted Data Not Found");
                }
                else
                {
                    // Read the IV that was used for encrypting the file
                    RijndaelAlg.IV = File.ReadAllBytes(IVFile);
                }
                // Decrypt the text from a file using the file name, key, and IV.
                string Final = DecryptTextFromFile(CryptFile, RijndaelAlg);
                // Display the decrypted string to the console.
                Console.WriteLine(Final);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
        public static void EncryptTextToFile(String Data, String FileName, Rijndael rij)
        {
            // Create or open the specified file.
            using (FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate, FileAccess.Write))
            // Create a CryptoStream using the FileStream 
            // and the passed key and initialization vector (IV).
            using (CryptoStream cStream = new CryptoStream(fStream, rij.CreateEncryptor(), CryptoStreamMode.Write))
            // Create a StreamWriter using the CryptoStream.
            using (StreamWriter sWriter = new StreamWriter(cStream))
            {
                // Write the data to the stream 
                // to encrypt it.
                sWriter.WriteLine(Data);
            }
        }
        public static string DecryptTextFromFile(String FileName, Rijndael rij)
        {
            // Open the specified file.
            using (FileStream fStream = File.Open(FileName, FileMode.Open, FileAccess.Read))
            // Create a CryptoStream using the FileStream 
            // and the passed key and initialization vector (IV).
            using (CryptoStream cStream = new CryptoStream(fStream, rij.CreateDecryptor(), CryptoStreamMode.Read))
            // Create a StreamReader using the CryptoStream.
            using (StreamReader sReader = new StreamReader(cStream))
            {
                // Read the data from the stream 
                // to decrypt it.
                return sReader.ReadToEnd();
            }
        }
    }
