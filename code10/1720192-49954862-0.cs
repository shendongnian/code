        public KuCoin_Balance GetAccountBalance()
        {
            KuCoin_Balance tmpBalance = new KuCoin_Balance();
            string domain = "https://api.kucoin.com";
            string endpoint = "/v1/user/info";
            string signatureResult = "";
            string SecretKey = apiSecret;
            long nonce = GetNonce();
            var stringToSign = $"/v1/user/info/{nonce}/";
            var signatureString = Convert.ToBase64String(Encoding.UTF8.GetBytes(stringToSign));
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(SecretKey);
            byte[] inputBytes = Encoding.UTF8.GetBytes(signatureString);
            using (var hmac = new HMACSHA256(secretKeyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                signatureResult = BitConverter.ToString(hashValue).Replace("-", "").ToLower();
            }
            KuCoin_Response Resp = new KuCoin_Response();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(domain + endpoint);
            request.Method = "GET";
            request.Headers["KC-API-KEY"] = apiKey;
            request.Headers["KC-API-NONCE"] = nonce.ToString();
            request.Headers["KC-API-SIGNATURE"] = signatureResult; // apiSecret;
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            Resp.StatusCode = "1";
                            Resp.StatusDescription = "Success";
                            Resp.ResponseString = reader.ReadToEnd();
                            //return Resp;
                        }//End of StreamReader
                    }
                }// End of using ResponseStream
            }
            catch (Exception ex)
            {
                Resp.StatusCode = "-1";
                Resp.StatusDescription = "Error";
                Resp.ResponseString = ex.Message.ToString() + "      " + response.StatusDescription;
                //return Resp;
            }
            return tmpBalance;
        }
