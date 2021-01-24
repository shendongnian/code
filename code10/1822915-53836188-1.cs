    class ExternalServiceContainerSigner : IExternalSignatureContainer
    {
        public void ModifySigningDictionary(PdfDictionary signDic)
        {
            signDic.Put(PdfName.FILTER, PdfName.ADOBE_PPKLITE);
            signDic.Put(PdfName.SUBFILTER, PdfName.ADBE_PKCS7_DETACHED);
        }
        public byte[] Sign(Stream data)
        {
            String hashAlgorithm = "SHA256";
            byte[] hash = DigestAlgorithms.Digest(data, hashAlgorithm);
            // call your external signature service to create a CMS signature
            // container for the given document hash and return the bytes of
            // that signature container.
            return CALL_YOUR_EXTERNAL_SIGNATURE_SERVICE_TO_CREATE_A_CMS_SIGNATURE_CONTAINER_FOR(hash);
        }
    }
