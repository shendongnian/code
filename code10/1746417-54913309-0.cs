    private static void SignPdf(string filename, string folderPdf, string pathToNewSignFile, string pathToCerts, string nameCert, string passCert)
    {      
        var pathToCert = GetFullNameFile(pathToCerts, nameCert); //Oh.. I did not know about the Path.Combine function.
                
        if (!File.Exists(pathToCert))
        {
            logger.Error("Certificate not exist " + pathToCert);
            return;
        }
                
        var pass = passCert.ToCharArray();
        FileStream fs;
        try
        {
            fs = new FileStream(pathToCert, FileMode.Open);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Could not open cert" + pathToCert);
            return;
        }
                      
        var store = new Pkcs12Store(fs, pass);
        
        fs.Close();
        
        var alias = "";
        // searching for private key
        foreach (string al in store.Aliases)
            if (store.IsKeyEntry(al) && store.GetKey(al).Key.IsPrivate) {
                alias = al;
                break;
            }
        var pk = store.GetKey(alias);
        ICollection<X509Certificate> chain = store.GetCertificateChain(alias).Select(c => c.Certificate).ToList();
                
        var parameters = pk.Key as RsaPrivateCrtKeyParameters;
        var pathPdf = GetFullNameFile(folderPdf, filename); //Oh.. I did not know about the Path.Combine function.
        var pathToSigPdf = GetFullNameFile(pathToNewSignFile, filename);
        if (!File.Exists(pathPdf))
        {
            logger.Error("Could not open file" + pathPdf + "  File not exist");
            return;
        }
                
        var reader = new PdfReader(pathPdf);
        
        FileStream fileStreamSigPdf;
        try
        {
            fileStreamSigPdf = new FileStream(pathToSigPdf, FileMode.Create);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Could not create file" + pathToSigPdf);
            return;
        }
        
        var stamper = PdfStamper.CreateSignature(reader, fileStreamSigPdf, '\0', null, true);
        var appearance = stamper.SignatureAppearance;
        appearance.Reason = "Утверждено";
        appearance.SetVisibleSignature("---> ExistSignatureName <-----");
        
        IExternalSignature pks = new PrivateKeySignature(parameters, DigestAlgorithms.SHA256);
        MakeSignature.SignDetached(appearance, pks, chain, null, null, null, 0, CryptoStandard.CMS);
        fileStreamSigPdf.Close();
        reader.Close();
        stamper.Close();
        
        logger.Info("Signed successfully " + filename);
    }
