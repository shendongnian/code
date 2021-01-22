    using System;
    using System.Xml;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Security.Cryptography.Xml;
    using System.Security.Cryptography.X509Certificates;
    // ...
    static void SignWithPfxPrivateKey()
    {
        X509Certificate2 certificate = new X509Certificate2(certFile, pfxPassword);
        RSACryptoServiceProvider rsaCsp = (RSACryptoServiceProvider) certificate.PrivateKey;   
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.PreserveWhitespace = true;
        if (loadFromString)
          xmlDoc.LoadXml(rawXml);   // load from a string
        else 
          xmlDoc.Load("test.xml");  // load from a document 
        // Sign the XML document. 
        SignXml(xmlDoc, rsaCsp);
        // Save the document.
        xmlDoc.Save("RsaSigningWithCert.xml");
        xmlDoc.Save(new XTWFND(Console.Out));
    }
    public static void SignXml(XmlDocument Doc, RSA Key)
    {
        // Check arguments.
        if (Doc == null)
            throw new ArgumentException("Doc");
        if (Key == null)
            throw new ArgumentException("Key");
        // Create a SignedXml object.
        SignedXml signedXml = new SignedXml(Doc);
        // Add the key to the SignedXml document.
        signedXml.SigningKey = Key;
        // Create a reference to be signed.
        Reference reference = new Reference();
        reference.Uri = "";
        // Add an enveloped transformation to the reference.
        XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
        reference.AddTransform(env);
        // Add the reference to the SignedXml object.
        signedXml.AddReference(reference);
        // Compute the signature.
        signedXml.ComputeSignature();
        // Get the XML representation of the signature and save
        // it to an XmlElement object.
        XmlElement xmlDigitalSignature = signedXml.GetXml();
        // Append the element to the XML document.
        Doc.DocumentElement.AppendChild(Doc.ImportNode(xmlDigitalSignature, true));
    }
