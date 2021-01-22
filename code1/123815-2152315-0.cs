     UsernameToken token = new UsernameToken("uname", "pwd", PasswordOption.SendPlainText);
     Service.RequestSoapContext.Security.Tokens.Add(token);
     System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();           
        
        
        public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
                {
                    public TrustAllCertificatePolicy()
                    { }
        
                    public bool CheckValidationResult(ServicePoint sp,
                     X509Certificate cert, WebRequest req, int problem)
                    {
        
                        return true;
                    }
                }
