        public Dictionary<string, string> DecodePayload(string payload) 
        {
            //Remove the bad part of signed_request
            //Begin
            string[] sB64String = payload.Split('.');
            payload = payload.Replace((sB64String[0] + "."), string.Empty);
            //End
            var encoding = new UTF8Encoding(); 
            var decodedJson = payload.Replace("=", string.Empty).Replace('-', '+').Replace('_', '/'); 
            var base64JsonArray = Convert.FromBase64String(decodedJson.PadRight(decodedJson.Length + (4 - decodedJson.Length % 4) % 4, '=')); 
            var json = encoding.GetString(base64JsonArray); 
            var jObject = JObject.Parse(json); 
            var parameters = new Dictionary<string, string>(); 
            parameters.Add("user_id", (string)jObject["user_id"] ?? ""); 
            parameters.Add("oauth_token", (string)jObject["oauth_token"] ?? ""); 
            var expires = ((long?)jObject["expires"] ?? 0); 
            parameters.Add("expires", expires > 0 ? expires.ToString() : ""); 
            parameters.Add("profile_id", (string)jObject["profile_id"] ?? ""); 
            return parameters; 
        }
