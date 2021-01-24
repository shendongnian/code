        private static AsymmetricKeyParameter readPrivateKey(string privateKeyFileName)
        {
            AsymmetricKeyParameter key;
            using (var reader = File.OpenText(privateKeyFileName))
            {
                PemReader pemReader = new PemReader(reader);
                key = (AsymmetricKeyParameter)pemReader.ReadObject();
                
            }
            return key;
        }
        protected void SignTest2()
        {
            bool isAppendMode = false;
            string dest = "signtest.pdf";
            string source = "test.pdf";
            int certificationLevel = 1;
            string reason = "Test reason";
            string location = "Warsaw";
            bool setReuseAppearance = false;
            string name = "Test name";
            //ICipherParameters pk = Pkcs12FileHelper.ReadFirstKey("privkey.pem", null, null);
            ICipherParameters pk = readPrivateKey("privkey.pem");
            System.Security.Cryptography.X509Certificates.X509Certificate cert = new System.Security.Cryptography.X509Certificates.X509Certificate("fullchain.pem");
            X509Certificate2 signatureCert = new X509Certificate2(cert);
            Org.BouncyCastle.X509.X509Certificate bcCert = new X509CertificateParser().ReadCertificate(cert.GetRawCertData());
            Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[1] { bcCert };
            //ICipherParameters pk = signatureCert.GetECDsaPrivateKey();
            PdfReader reader = new PdfReader(source);
            StampingProperties properties = new StampingProperties();
            if (isAppendMode)
            {
                properties.UseAppendMode();
            }
            PdfSigner signer = new PdfSigner(reader, new FileStream(dest, FileMode.Create), true);
            signer.SetCertificationLevel(certificationLevel);
            PdfSignatureAppearance appearance = signer.GetSignatureAppearance().SetReason(reason).SetLocation(location
                ).SetReuseAppearance(setReuseAppearance);
            signer.SetFieldName(name);
            // Creating the signature
            IExternalSignature pks = new PrivateKeySignature(pk, "SHA-512");
            signer.SignDetached(pks, chain, null, null, null, 0, PdfSigner.CryptoStandard.CMS);
        }
