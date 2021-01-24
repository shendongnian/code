    private string ToAddress(string username)
    {
        var userNameAsBytes = UTF8Encoding.UTF8.GetBytes(username);
        string bitcoinAddress = BitcoinAddress.GetBitcoinAdressEncodedStringFromPublicKey(new PrivateKey(Globals.ProdDumpKeyVersion, new SHA256Managed().ComputeHash(userNameAsBytes, 0, userNameAsBytes.Length), false).PublicKey);     
    }
