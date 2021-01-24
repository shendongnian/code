    	private static string CreateJWTTokenBountyCastle(byte[] certificate, string psw, string serviceUserIss, string serviceUserSub, string serviceUserAud)
        {
            string jwt;
            using (RSACryptoServiceProvider rsax = OpenCertificate(certificate, psw)) // open using BouncyCastle and avoid usage of X502Certificate2
            {
                Dictionary<string, object> payload = new Dictionary<string, object>(){
                    { "iss", serviceUserIss },
                   { "sub", serviceUserSub},
                   { "aud", serviceUserAud},
                jwt = Jose.JWT.Encode(payload, rsax, Jose.JwsAlgorithm.RS256);
            }
            return jwt;
        }
		private static RSACryptoServiceProvider OpenCertificate(byte[] certB, string pwd)
        {
            MemoryStream ms = new MemoryStream(certB);
            Pkcs12Store st = new Pkcs12Store(ms, pwd.ToCharArray());
            var alias = st.Aliases.Cast<string>().FirstOrDefault(p => st.IsKeyEntry(p));
            AsymmetricKeyEntry keyEntry = st.GetKey(alias);
            var kkey = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)keyEntry.Key);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(kkey);
            return rsa;
        }
