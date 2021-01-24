    public byte[] Sign(byte[] document, X509Certificate2 certificate, ITSAClient tsaClient)
    {
        byte[] signedDocument = null;
        IExternalSignature signature = new X509Certificate2Signature(certificate, "SHA-1");
        Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
        Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] { cp.ReadCertificate(certificate.RawData) };
        PdfReader reader = new PdfReader(document);
        MemoryStream ms = new MemoryStream();
        PdfStamper st = PdfStamper.CreateSignature(reader, ms, '\0');
        PdfSignatureAppearance sap = st.SignatureAppearance;
        //sap.CertificationLevel = PdfSignatureAppearance.CERTIFIED_NO_CHANGES_ALLOWED;
        sap.CertificationLevel = PdfSignatureAppearance.CERTIFIED_FORM_FILLING;
        sap.SignatureCreator = "NAME";
        sap.Reason = "REASON";
        sap.Contact = "CONTACT";
        sap.Location = "LOCATION";
        sap.SignDate = DateTime.Now;
        RectangleF rectangle = new RectangleF(400.98139f, 54.88828f, 530, 84.88828f);
        sap.Layer2Font = iTextSharp.text.FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 7f);
        sap.Layer2Font.Color = iTextSharp.text.BaseColor.RED;
        sap.Layer2Text = string.Format("Signed for testing: {0}", DateTime.Now.ToString("dd.MM.yyyy."));
        sap.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;
        sap.SetVisibleSignature(new iTextSharp.text.Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height), 1, null);
        MakeSignature.SignDetached(sap, signature, chain, null, null, tsaClient, 0, CryptoStandard.CMS);
        st.Close();
        ms.Flush();
        signedDocument = ms.ToArray();
        ms.Close();
        reader.Close();
        return signedDocument;
    }
