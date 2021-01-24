        virtual public PdfPKCS7 VerifySignature(String name) {
            PdfDictionary v = GetSignatureDictionary(name);
            if (v == null)
                return null;
            PdfName sub = v.GetAsName(PdfName.SUBFILTER);
            PdfString contents = v.GetAsString(PdfName.CONTENTS);
            PdfPKCS7 pk = null;
            if (sub.Equals(PdfName.ADBE_X509_RSA_SHA1)) {
                PdfString cert = v.GetAsString(PdfName.CERT);
                if (cert == null)
                    cert = v.GetAsArray(PdfName.CERT).GetAsString(0);
                pk = new PdfPKCS7(contents.GetOriginalBytes(), cert.GetBytes());
            }
            else
                pk = new PdfPKCS7(contents.GetOriginalBytes(), sub);
