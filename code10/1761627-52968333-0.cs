        AsymmetricKeyParameter akp;
        var decryptEngine = new Pkcs1Encoding(new RsaEngine());
        using (var txtreader = new StringReader(privateKey))
        {
            akp = (AsymmetricKeyParameter)new PemReader(txtreader).ReadObject();
            decryptEngine.Init(false, akp);
        }
