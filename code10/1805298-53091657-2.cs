        private static string Decode(string htmlEncoded)
        {
            try
            {
                string regularEncodedString = WebUtility.UrlDecode(htmlEncoded);
                byte[] decoded = Convert.FromBase64String(regularEncodedString);
                return Encoding.ASCII.GetString(decoded);
            }
            catch(Exception)
            {
                return "Decoding failed";
            }
        }
