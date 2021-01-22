                CspParameters cspParams = new CspParameters();
                // Specify the container name using the passed variable.
                cspParams.KeyContainerName = ContainerName;
                //Create a new instance of RSACryptoServiceProvider. 
                //Pass the CspParameters class to use the 
                //key in the container.
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParams);
                //Delete the key entry in the container.
                rsa.PersistKeyInCsp = false;
                //Call Clear to release resources and delete the key from the container.
                rsa.Clear();
