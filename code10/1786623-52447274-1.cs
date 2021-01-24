    PdfReader reader = new PdfReader(signedDocument);
    FileStream os = new FileStream(ENABLED_PDF, FileMode.Create);
    PdfStamper pdfStamper = new PdfStamper(reader, os, (char)0, true);
    AdobeLtvEnabling adobeLtvEnabling = new AdobeLtvEnabling(pdfStamper);
    IOcspClient ocsp = new OcspClientBouncyCastle();
    ICrlClient crl = new CrlClientOnline();
    adobeLtvEnabling.enable(ocsp, crl);
    pdfStamper.Close();
