        private string GenerateHash(string password, double timeStamp, string nonce)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var pwHash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                using (SHA1Managed sha1total = new SHA1Managed())
                {
                    string hexaHashPW = "";
                    foreach (byte b in pwHash)
                    {
                        hexaHashPW += String.Format("{0:x2}", b);
                    }
                    var hmacPW = new HMACSHA1();
                    hmacPW.ComputeHash(pwHash);
                    sha1total.ComputeHash(Encoding.UTF8.GetBytes(timeStamp.ToString() + nonce + hexaHashPW + _SecretApiKey));
                    var hmac = new HMACSHA1();
                    string hexaHashTotal = "";
                    foreach (byte b in sha1total.Hash)
                    {
                        hexaHashTotal += String.Format("{0:x2}", b);
                    }
                    hmac.ComputeHash(sha1total.Hash);
                    return hexaHashTotal.ToLower();
                }
            }
        }
