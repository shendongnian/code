    System.Net.ServicePointManager.ServerCertificateValidationCallback = 
         (sender, certificate, chain, policyErrors) => 
         {
            var isValid = false;
            // some checking logic
            return isValid;
         };
