    public class ApiRequest
    {
        public string BaseUrl { get; set; }
        public string Endpoint { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
        public string Method { get; set; }
        public string Body { get; set; }
        /// <summary>
        /// Each API request needs to be signed so the sender can be identified.
        /// This property generates the signature based on the current request.
        /// </summary>
        public string Signature
        {
            get
            {
                var unixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
                var asciiEncoding = new ASCIIEncoding();
                var hmac = new HMACSHA256(asciiEncoding.GetBytes(Secret));
                string signature = Key + unixTimestamp + Method.ToUpper() + Endpoint + (Body ?? string.Empty);
                byte[] signatureBytes = asciiEncoding.GetBytes(signature);
                byte[] hashedSignatureBytes = hmac.ComputeHash(signatureBytes);
                string hexSignature = string.Join(string.Empty, Array.ConvertAll(hashedSignatureBytes, hb => hb.ToString("X2")));
                return hexSignature;
            }
        }
    }
