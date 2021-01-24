            static void Main(string[] args)
            {
                 // Test 1: Encrypted text from C#
                 MyCryptoClass mcc = MyCryptoClass.Instance;
                 string encryptedText = mcc.EncryptText("This is a plain text which needs to be encrypted...");
                 Console.WriteLine("Encrypted text (base64): " + encryptedText);
                 string decryptedText = mcc.DecryptText(encryptedText);
                 Console.WriteLine("Decrypted text: " + decryptedText);
                 // Test 2: Encrypted text from Java
                 string javaEncryptedText = "mL4ajZtdRgD8CtGSfJGkT24Ebw4SrGUGKQI6bvBw1ziCO/J7SeLiyIw41zumTHMMD9GOYK+kR79CVcpoaHT9TQ==";
                 Console.WriteLine("Encrypted text from Java (base64): " + javaEncryptedText);
                 string javaDecryptedText = mcc.DecryptText(javaEncryptedText);
                 Console.WriteLine("Decrypted text from Java: " + javaDecryptedText);
            }
