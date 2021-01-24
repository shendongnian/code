    public byte[] FirmaFileBouncy(String NomeFile, X509Certificate2 cert, ref string RisFirma)
            {
                String NomeFirma = NomeFile + ".p7m";
    
                try
                {
                    SHA256Managed hashSha256 = new SHA256Managed();
                    byte[] certHash = hashSha256.ComputeHash(cert.RawData);
    
                    EssCertIDv2 essCert1 = new EssCertIDv2(new Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier("2.16.840.1.101.3.4.2.1"), certHash);
                    SigningCertificateV2 scv2 = new SigningCertificateV2(new EssCertIDv2[] { essCert1 });
    
                    Org.BouncyCastle.Asn1.Cms.Attribute CertHAttribute = new Org.BouncyCastle.Asn1.Cms.Attribute(Org.BouncyCastle.Asn1.Pkcs.PkcsObjectIdentifiers.IdAASigningCertificateV2, new DerSet(scv2));
                    Asn1EncodableVector v = new Asn1EncodableVector();
                    v.Add(CertHAttribute);
    
                    Org.BouncyCastle.Asn1.Cms.AttributeTable AT = new Org.BouncyCastle.Asn1.Cms.AttributeTable(v);
                    CmsSignedDataGenWithRsaCsp cms = new CmsSignedDataGenWithRsaCsp();
    
                    dynamic rsa = (RSACryptoServiceProvider)cert.PrivateKey;
                    Org.BouncyCastle.X509.X509Certificate certCopy = DotNetUtilities.FromX509Certificate(cert);
                    cms.MyAddSigner( rsa, certCopy,  "1.2.840.113549.1.1.1", "2.16.840.1.101.3.4.2.1", AT, null);
                    
                    ArrayList certList = new ArrayList();
                    certList.Add(certCopy);
    
                    Org.BouncyCastle.X509.Store.X509CollectionStoreParameters PP = new Org.BouncyCastle.X509.Store.X509CollectionStoreParameters(certList);
                    Org.BouncyCastle.X509.Store.IX509Store st1 = Org.BouncyCastle.X509.Store.X509StoreFactory.Create("CERTIFICATE/COLLECTION", PP);
                    
                    cms.AddCertificates(st1);
    
                    //mi ricavo il file da firmare
                    FileInfo File__1 = new FileInfo(NomeFile);
                    CmsProcessableFile file__2 = new CmsProcessableFile(File__1);
                    CmsSignedData Firmato = cms.Generate(file__2, true);
                    byte[] Encoded = Firmato.GetEncoded();
    
                    File.WriteAllBytes(NomeFirma, Encoded);
    
                    RisFirma = "true";
    
                    return Encoded;
    
                } catch (Exception ex)  {
    
                    RisFirma = ex.ToString();
                    return null;
                }
    
            }
