    using System;
    using System.Drawing;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.security;
    using NUnit.Framework;
    using Org.BouncyCastle.Asn1.X509;
    [...]
    [Test]
    public void testEnableKenJankasPdf()
    {
        byte[] document = File.ReadAllBytes(@"[...]\test.pdf");
        X509Certificate2 certificate = new X509Certificate2(@"[...]\cert.pfx", "misko123");
        X509Certificate2 extra1 = new X509Certificate2(@"[...]\AscertiaPublicCA1.crt");
        X509Certificate2 extra2 = new X509Certificate2(@"[...]\AscertiaRootCA2.crt");
        ITSAClient tsaClient = new TSAClientBouncyCastle("http://timestamp.comodoca.com");
        byte[] signedDocument = Sign(document, certificate, tsaClient);
        File.WriteAllBytes(@"[...]\Test_KenJanka-signed.pdf", signedDocument);
        PdfReader reader = new PdfReader(signedDocument);
        FileStream os = new FileStream(@"[...]\Test_KenJanka-enabled.pdf", FileMode.Create);
        PdfStamper pdfStamper = new PdfStamper(reader, os, (char)0, true);
        AdobeLtvEnabling adobeLtvEnabling = new AdobeLtvEnabling(pdfStamper);
        AdobeLtvEnabling.extraCertificates.Add(new Org.BouncyCastle.X509.X509Certificate(X509CertificateStructure.GetInstance(extra1.GetRawCertData())));
        AdobeLtvEnabling.extraCertificates.Add(new Org.BouncyCastle.X509.X509Certificate(X509CertificateStructure.GetInstance(extra2.GetRawCertData())));
        IOcspClient ocsp = new OcspClientBouncyCastle();
        ICrlClient crl = new CrlClientOnline();
        adobeLtvEnabling.enable(ocsp, crl);
        pdfStamper.Close();
    }
