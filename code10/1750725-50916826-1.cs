        public static string DecryptString(byte[] data, string password)
        {
            byte[] allBytes = data;
            byte[] one = new byte[]{1};
            string plaintext = null;
            // this is all of the bytes
            byte[] passwordByteArray = ToByteArray(password);
            using (var aes = Aes.Create())
            {
                aes.KeySize = KeySize;
                aes.BlockSize = BlockSize;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                // get the key salt
                byte[] keySalt = new byte[KeySize / 8];
                Array.Copy(allBytes, keySalt, keySalt.Length);
                // Yii2 says
                //$key = $this->hkdf($this->kdfHash, $secret, $keySalt, $info, $keySize);
                //
                //Yii2 hkdf says
                //$prKey = hash_hmac($algo, $inputKey, $salt, true);
                //$hmac = '';
                //$outputKey = '';
                //for ($i = 1; $i <= $blocks; $i++) {
                //  $hmac = hash_hmac($algo, $hmac . $info . chr($i), $prKey, true);
                //  $outputKey .= $hmac;
                //}
                // chr($i) is the char byte of 1;
                // the blocksize is 1
                // info here is nothing
                // hash first key with keysalt and password
                HMACSHA256 hmac = new HMACSHA256(keySalt);
                byte[] computedHash = hmac.ComputeHash(passwordByteArray);
                // hash primary key with one byte and computed hash
                HMACSHA256 hmac2 = new HMACSHA256(computedHash);
                byte[] prKeyFull = hmac2.ComputeHash(one);
                byte[] prKey = new byte[KeySize / 8];
                Array.Copy(prKeyFull, 0, prKey, 0, prKey.Length);
                // if we want to verify the mac hash this is where we would do it.
                // Yii2 encryption data.
                // $encrypted = openssl_encrypt($data, $this->cipher, $key, OPENSSL_RAW_DATA, $iv);
                //
                //$authKey = $this->hkdf($this->kdfHash, $key, null, $this->authKeyInfo, $keySize);
                //hashed = $this->hashData($iv. $encrypted, $authKey);
                //hashed = [macHash][data]
                // get the MAC code
                byte[] MAC = new byte[MacHashSize / 8];
                Array.Copy(allBytes, keySalt.Length, MAC, 0, MAC.Length);
                // get our IV
                byte[] iv = new byte[BlockSize / 8];
                Array.Copy(allBytes, (keySalt.Length + MAC.Length), iv, 0, iv.Length);
                // get the data we need to decrypt
                byte[] cipherBytes = new byte[allBytes.Length - iv.Length - MAC.Length - keySalt.Length];
                Array.Copy(allBytes, (keySalt.Length + MAC.Length + iv.Length), cipherBytes, 0, cipherBytes.Length);
                // Create a decrytor to perform the stream transform.
                var decryptor = aes.CreateDecryptor(prKey, iv);
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            //Read the decrypted bytes from the decrypting stream
                            //and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
