      ServicePointManager.ServerCertificateValidationCallback +=
                new System.Net.Security.RemoteCertificateValidationCallback(customXertificateValidation);
        private static bool customXertificateValidation(
            object sender, X509Certificate cert,
            X509Chain chain, System.Net.Security.SslPolicyErrors error)
        {
            // check here 'cert' parameter properties (ex. Subject) and based on the result 
            // you expect return true or false
            return false/true;
        }
 
