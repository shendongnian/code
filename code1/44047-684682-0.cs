        using System.Security.Cryptography;
        using System.Security.Cryptography.Xml;
        // retrieve from named keystore
        private void btnRetrieve_Click(object sender, RoutedEventArgs e)
        {
            string keyContainer = this.tbContainerName.Text;
            CspParameters parms = new CspParameters(1);
            parms.Flags = CspProviderFlags.UseMachineKeyStore;
            parms.KeyContainerName = keyContainer;
            parms.KeyNumber = 2;
            RSACryptoServiceProvider RsaCsp = new RSACryptoServiceProvider(parms);
            tbPubKeyBlob.Text = RsaCsp.ToXmlString(false);
        }
        // generate key pair
        private void btnCreateKeypair_Click(object sender, RoutedEventArgs e)
        {
            int keySize = 0;
            if (!System.Int32.TryParse(this.tbKeySize.Text, out keySize))
                keySize = 1024;
            byte[] key = Keys.GenerateKeyPair(keySize);
            RSACryptoServiceProvider RsaCsp = new RSACryptoServiceProvider();
            RsaCsp.ImportCspBlob(key);
            tbPubKeyBlob.Text = RsaCsp.ToXmlString(false);
            
        }
