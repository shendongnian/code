    internal class CloudFrontSecurityProvider
    {
        private readonly RSACryptoServiceProvider privateKey;
        private readonly string privateKeyId;
        private readonly SHA1Managed sha1 = new SHA1Managed();
        public CloudFrontSecurityProvider(string privateKeyId, string privateKey)
        {
            this.privateKey = new RSACryptoServiceProvider();
            RSACryptoServiceProvider.UseMachineKeyStore = false;
            this.privateKey.FromXmlString( privateKey );
            this.privateKeyId = privateKeyId;
        }
        private static int GetUnixTime(DateTime time)
        {
            DateTime referenceTime = new DateTime(1970, 1,1);
            return (int) (time - referenceTime).TotalSeconds;
            
        }
        public string GetCannedUrl(string url, DateTime expiration)
        {
            string expirationEpoch = GetUnixTime( expiration ).ToString();
            string policy =
                @"{""Statement"":[{""Resource"":""<url>"",""Condition"":{""DateLessThan"":{""AWS:EpochTime"":<expiration>}}}]}".
                    Replace( "<url>", url ).
                    Replace( "<expiration>", expirationEpoch );
            string signature = GetUrlSafeString( Sign( policy ) );
            return url + string.Format("?Expires={0}&Signature={1}&Key-Pair-Id={2}", expirationEpoch, signature, this.privateKeyId);
        }
        private static string GetUrlSafeString(byte[] data)
        {
            return Convert.ToBase64String( data ).Replace( '+', '-' ).Replace( '=', '_' ).Replace( '/', '~' );
        }
        private byte[] Sign(string data)
        {
                byte[] plainbytes = Encoding.UTF8.GetBytes(data);
                byte[] hash = sha1.ComputeHash(plainbytes);
                return this.privateKey.SignHash(hash, "SHA1");
        }
    }
