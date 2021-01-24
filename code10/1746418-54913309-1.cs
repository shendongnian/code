    public string PrepareSignatureAndGetHash()
        {
            var hash = string.Empty;
            
            using (var reader = new PdfReader("PathTemplate"))
            {
                using (var fileStream = File.OpenWrite("PathToTemp"))
                {
                    using (var stamper = PdfStamper.CreateSignature(reader, fileStream, '0', null, true))
                    {
                        var signatureAppearance = stamper.SignatureAppearance;
                        signatureAppearance.SetVisibleSignature("ExistSignatureName");
                        IExternalSignatureContainer external = new ExternalBlankSignatureContainer(PdfName.ADOBE_PPKLITE, PdfName.ADBE_PKCS7_DETACHED);
                        signatureAppearance.Reason = "Sig";
                        signatureAppearance.Layer2Text = "Super SIG";
                        
                        signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;
                    
                        MakeSignature.SignExternalContainer(signatureAppearance, external, 8192);
                        
                        using (var contentStream = signatureAppearance.GetRangeStream())
                        {
                            hash = string.Join(string.Empty, SHA1.Create().ComputeHash(contentStream).Select(x => x.ToString("X2")));
                        }
                    }
                }
            }
        return hash;
    }
