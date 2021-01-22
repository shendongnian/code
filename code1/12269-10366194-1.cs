    using System;
    using System.IO;
    using System.Text;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.Crypto.Generators;
    using Org.BouncyCastle.Crypto.Modes;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Security;
    
    namespace Encryption{
    
        public class AESGCM
        {	
            static private readonly SecureRandom Random = new SecureRandom();
    
            static public int NonceBitSize = 128;
            static public int MacBitSize = 128;
            static public int KeyBitSize = 256;
    		static public int MinPasswordLength = 12;
    		static public int SaltBitSize = 64;
    
            /// <summary>
            /// Simple Encryption And Authentication (AES-GCM) of a UTF8 string.
            /// </summary>
            /// <param name="secretMessage">The secret message.</param>
            /// <param name="key">The key.</param>
            /// <param name="nonSecretPayload">Optional non-secret payload.</param>
            /// <returns>Encrypted Message</returns>
            /// <remarks>
            /// Adds overhead of (Optional-Payload + BlockSize(16) + Message +  HMac-Tag(16)) * 1.33 Base64
            /// </remarks>
            static public string SimpleEncrypt(string secretMessage, byte[] key, byte[] nonSecretPayload =null)
            {
    			//User Error Checks
                if (key == null || key.Length != KeyBitSize / 8)
                    throw new ArgumentException(String.Format("Key needs to be {0} bit!",KeyBitSize), "key");
    
                if (string.IsNullOrEmpty(secretMessage))
                	throw new ArgumentException("Secret Message Required!", "secretMessage");
    
    			//Non-secret Payload Optional
                nonSecretPayload = nonSecretPayload ?? new byte[] { };
               
     			var plainText = Encoding.UTF8.GetBytes(secretMessage);
    
    			//Using random nonce large enough not to repeat
                var nonce = new byte[NonceBitSize / 8];
                Random.NextBytes(nonce,0,nonce.Length);
    
                var cipher = new GcmBlockCipher(new AesFastEngine());
                var parameters = new AeadParameters(new KeyParameter(key), MacBitSize, nonce, nonSecretPayload);
                cipher.Init(true, parameters);
    
    			//Generate Cipher Text With Auth Tag
                var cipherText = new byte[cipher.GetOutputSize(plainText.Length)];
                var len = cipher.ProcessBytes(plainText, 0, plainText.Length, cipherText, 0);
                cipher.DoFinal(cipherText, len);
    
    			//Assemble Message
                using (var combinedStream = new MemoryStream())
                {
                    using (var binaryWriter = new BinaryWriter(combinedStream))
                    {
    					//Prepend Authenticated Payload
                        binaryWriter.Write(nonSecretPayload);
    					//Prepend Nonce
                        binaryWriter.Write(nonce);
    					//Write Cipher Text
                        binaryWriter.Write(cipherText);
                    }
                    return Convert.ToBase64String(combinedStream.ToArray());
                }
            }
    
            /// <summary>
            /// Simple Decryption & Authentication (AES-GCM) of a UTF8 Message
            /// </summary>
            /// <param name="encryptedMessage">The encrypted message.</param>
            /// <param name="key">The key.</param>
            /// <param name="nonSecretPayloadLength">Length of the optional non-secret payload.</param>
            /// <returns>Decrypted Message</returns>
            static public string SimpleDecrypt(string encryptedMessage, byte[] key, int nonSecretPayloadLength =0)
            {
        		//User Error Checks
        		if (key == null || key.Length != KeyBitSize / 8)
            		throw new ArgumentException(String.Format("Key needs to be {0} bit!",KeyBitSize), "key");
    
                if (string.IsNullOrWhiteSpace(encryptedMessage))
                    throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");
    
                var messageArray = Convert.FromBase64String(encryptedMessage);
                using(var cipherStream = new MemoryStream(messageArray))
                using (var cipherReader = new BinaryReader(cipherStream))
                {
    				//Grab Payload
                    var nonSecretPayload =cipherReader.ReadBytes(nonSecretPayloadLength);
    				
    				//Grab Nonce
                    var nonce = cipherReader.ReadBytes(NonceBitSize / 8);
                    
    				var cipher = new GcmBlockCipher(new AesFastEngine());
    		 		var parameters = new AeadParameters(new KeyParameter(key), MacBitSize, nonce, nonSecretPayload);
                    cipher.Init(false, parameters);
    				
    				//Decrypt Cipher Text
    				var cipherText = cipherReader.ReadBytes(messageArray.Length - nonSecretPayloadLength - nonce.Length);
                    var plainText = new byte[cipher.GetOutputSize(cipherText.Length)];
                    var len = cipher.ProcessBytes(cipherText, 0, cipherText.Length, plainText, 0);
                    cipher.DoFinal(plainText, len);
    
    				//Grab Authentication
                    var cipherTag = new byte[MacBitSize/8];
                    Array.Copy(cipherText, cipherText.Length - cipherTag.Length, cipherTag, 0, cipherTag.Length);
    
    				//Check Autentication
    				var calcTag = cipher.GetMac();
                    var auth = true;
                    for(var i=0;i< cipherTag.Length;i++)
                        auth = auth && cipherTag[i] == calcTag[i];
    
    				//Return Null if it doesn't authenticate
                    return !auth ? null : Encoding.UTF8.GetString(plainText);
                }
                
            }
    
            /// <summary>
            /// Simple Encryption And Authentication (AES-GCM) of a UTF8 String
            /// using key derived from a password.
            /// </summary>
            /// <param name="secretMessage">The secret message.</param>
            /// <param name="password">The password.</param>
            /// <returns>Encrypted Message</returns>
            /// <remarks>Significantly less secure than using random binary keys.
            ///  Adds additional non secret payload for key generation parameters. 
            /// </remarks>
            static public string SimpleEncryptWithPassword(string secretMessage, string password)
            {
                //User Error Checks
                if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
                    throw new ArgumentException(String.Format("Must have a password of at least {0} characters!", MinPasswordLength), "password");
    
                if (string.IsNullOrEmpty(secretMessage))
                    throw new ArgumentException("Secret Message Required!", "secretMessage");
    
                var generator = new Pkcs5S2ParametersGenerator();
    
                //Use Random Salt to minimize pre-generated weak password attacks.
                var salt = new byte[SaltBitSize / 8];
                Random.NextBytes(salt);
    
                //iterations are not secret, nor does it need to change randomly
                //I'm just using random data because i prefer the non-secret payload looking
                //like random data
                var iters = new byte[8];
                Random.NextBytes(iters);
                var m = Math.Abs(BitConverter.ToInt32(iters, 0)) % 10;
                var a = Math.Abs(BitConverter.ToInt32(iters, 4)) % 10000;
                var iterations = 1000 * m + a + 5000;
    
                generator.Init(
                    PbeParametersGenerator.Pkcs5PasswordToBytes(password.ToCharArray()),
                    salt,
                    iterations);
    
                //Generate Key
                var key = (KeyParameter)generator.GenerateDerivedMacParameters(KeyBitSize);
    
                //Create Non Secret Payload
                var payload = new byte[salt.Length + iters.Length];
                Array.Copy(salt, payload, salt.Length);
                Array.Copy(iters, 0, payload, salt.Length, iters.Length);
    
                return SimpleEncrypt(secretMessage, key.GetKey(), payload);
            }
    
            /// <summary>
            /// Simple Decryption and Authentication of a UTF8 message
            /// using a key derived from a password
            /// </summary>
            /// <param name="encryptedMessage">The encrypted message.</param>
            /// <param name="password">The password.</param>
            /// <returns>Decrypted Message</returns>
            /// <remarks>Significantly less secure than using random binary keys. </remarks>
            static public string SimpleDecryptWithPassword(string encryptedMessage, string password)
            {
                //User Error Checks
                if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
                    throw new ArgumentException(String.Format("Must have a password of at least {0} characters!",MinPasswordLength), "password");
    
                if (string.IsNullOrWhiteSpace(encryptedMessage))
                    throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");
    
                var generator = new Pkcs5S2ParametersGenerator();
    
                //Grab Salt and Iterations from Payload
                var salt = new byte[SaltBitSize / 8];
                var iters = new byte[8];
                var message = Convert.FromBase64String(encryptedMessage);
                Array.Copy(message, salt, salt.Length);
                Array.Copy(message, salt.Length, iters, 0, iters.Length);
                var m = Math.Abs(BitConverter.ToInt32(iters, 0)) % 10;
                var a = Math.Abs(BitConverter.ToInt32(iters, 4)) % 10000;
                var iterations = 1000 * m + a + 5000;
    
                generator.Init(
                    PbeParametersGenerator.Pkcs5PasswordToBytes(password.ToCharArray()),
                    salt,
                    iterations);
    
                //Generate Key
                var key = (KeyParameter)generator.GenerateDerivedMacParameters(KeyBitSize);
    
                return SimpleDecrypt(encryptedMessage, key.GetKey(), salt.Length + iters.Length);
            }
        }
    }
