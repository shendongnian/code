        var cp = new CspParameters();
        cp.KeyContainerName = ContainerName;
        // Create a new instance of RSACryptoServiceProvider that accesses
        // the key container.
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);
        // Delete the key entry in the container.
        rsa.PersistKeyInCsp = false;
        // Call Clear to release resources and delete the key from the container.
        rsa.Clear();
