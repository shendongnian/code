    public static string ConvertToNewKey(string oldPrivateKey)
    {
        // get the current container name from the database...
        rsa.PersistKeyInCsp = false;
        rsa.Clear();
        rsa = null;
        string privateKey = AssignNewKey(true); // create the new public key and container name and write them to the database...
           // re-encrypt existing data to use the new keys and write to database...
        return privateKey;
    }
    public static string AssignNewKey(bool ReturnPrivateKey){
         string containerName = DateTime.Now.Ticks.ToString();
         // create the new key...
         // saves container name and public key to database...
         // and returns Private Key XML.
    }
    
