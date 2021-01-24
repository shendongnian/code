    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using Org.BouncyCastle.Cms;
    using Org.BouncyCastle.Pkcs;
    using Org.BouncyCastle.X509;
    using Org.BouncyCastle.X509.Store;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Asn1;
    using Org.BouncyCastle.Asn1.Cms;
    using Org.BouncyCastle.Asn1.Esf;
    
    namespace assinador
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] entradaArray = File.ReadAllBytes(@"certificado/arquivoTeste.txt");
    
                AsymmetricKeyParameter chavePrivada;
                
                X509Certificate certificadoX509 = getCertificadoX509(@"certificado/certificado.p12", "123!@#", out chavePrivada);
    
                SHA512Managed hashSHA512 = new SHA512Managed();
                SHA256Managed hashSHA256 = new SHA256Managed();
                byte[] certificadoX509Hash = hashSHA256.ComputeHash(certificadoX509.GetEncoded());
                byte[] EntradaHash = hashSHA512.ComputeHash(entradaArray);
    
                CmsSignedDataGenerator geradorCms = new CmsSignedDataGenerator();
    
                //
                //atributos
                //
                Asn1EncodableVector atributosAssinados = new Asn1EncodableVector();
                
                //1.2.840.113549.1.9.3 -> ContentType
                //1.2.840.113549.1.7.1 -> RSA Security Data Inc
                atributosAssinados.Add(new Org.BouncyCastle.Asn1.Cms.Attribute(CmsAttributes.ContentType, new DerSet(new DerObjectIdentifier("1.2.840.113549.1.7.1"))));
    
                //1.2.840.113549.1.9.5 -> Signing Time
                atributosAssinados.Add(new Org.BouncyCastle.Asn1.Cms.Attribute(CmsAttributes.SigningTime, new DerSet(new DerUtcTime(DateTime.Now))));
    
                //1.2.840.113549.1.9.4 -> messageDigest
                atributosAssinados.Add(new Org.BouncyCastle.Asn1.Cms.Attribute(CmsAttributes.MessageDigest, new DerSet(new DerOctetString(EntradaHash))));
    
                //2.16.840.1.101.3.4.2.3 -> SHA-512
                //2.16.840.1.101.3.4.2.1 -> SHA-256
                //1.2.840.113549.1.9.16.5.1 -> sigPolicyQualifier-spuri
                DerObjectIdentifier identificadorPolicyID = new DerObjectIdentifier("1.2.840.113549.1.9.16.2.15");
                byte[] policyHASH = System.Text.Encoding.ASCII.GetBytes("0F6FA2C6281981716C95C79899039844523B1C61C2C962289CDAC7811FEEE29E");
                List<SigPolicyQualifierInfo> sigPolicyQualifierInfos = new List<SigPolicyQualifierInfo>();
                Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier algoritmoIdentificador = new Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier("2.16.840.1.101.3.4.2.3");
                SigPolicyQualifierInfo bcSigPolicyQualifierInfo = new SigPolicyQualifierInfo(new DerObjectIdentifier("1.2.840.113549.1.9.16.5.1"), new DerIA5String("http://politicas.icpbrasil.gov.br/PA_AD_RB_v2_2.der"));
                sigPolicyQualifierInfos.Add(bcSigPolicyQualifierInfo);
                SignaturePolicyId signaturePolicyId = new SignaturePolicyId(DerObjectIdentifier.GetInstance(new DerObjectIdentifier("2.16.76.1.7.1.6.2.2")), new OtherHashAlgAndValue(algoritmoIdentificador, new DerOctetString(policyHASH)), sigPolicyQualifierInfos);
                atributosAssinados.Add(new Org.BouncyCastle.Asn1.Cms.Attribute(identificadorPolicyID, new DerSet(signaturePolicyId)));
    
                //1.2.840.113549.1.9.16.2.47 -> id-aa-signingCertificateV2
                Org.BouncyCastle.Asn1.Ess.EssCertIDv2 essCertIDv2;
                essCertIDv2 = new Org.BouncyCastle.Asn1.Ess.EssCertIDv2(certificadoX509Hash);
                atributosAssinados.Add(new Org.BouncyCastle.Asn1.Cms.Attribute(new DerObjectIdentifier("1.2.840.113549.1.9.16.2.47"), new DerSet(essCertIDv2)));
    
                AttributeTable atributosAssinadosTabela = new AttributeTable(atributosAssinados);
    
                //geradorCms.AddSigner(chavePrivada, certificadoX509, CmsSignedDataGenerator.DigestSha256, new DefaultSignedAttributeTableGenerator(atributosAssinadosTabela), null);
                geradorCms.AddSigner(chavePrivada, certificadoX509, CmsSignedDataGenerator.DigestSha512, new DefaultSignedAttributeTableGenerator(atributosAssinadosTabela), null);
    
                List<X509Certificate> certificadoX509Lista = new List<X509Certificate>();
                certificadoX509Lista.Add(certificadoX509);
                //storeCerts.AddRange(chain);
                
                X509CollectionStoreParameters parametrosArmazem = new X509CollectionStoreParameters(certificadoX509Lista);
                IX509Store armazemCertificado = X509StoreFactory.Create("CERTIFICATE/COLLECTION", parametrosArmazem);
                geradorCms.AddCertificates(armazemCertificado);
    
                var dadosAssinado = geradorCms.Generate(new CmsProcessableByteArray(entradaArray), true); // encapsulate = false for detached signature
                
                Console.WriteLine("Codificado => " + Convert.ToBase64String(dadosAssinado.GetEncoded()));
            }
    
            public static X509Certificate getCertificadoX509(string arquivoCertificado, string senha, out AsymmetricKeyParameter chavePrivada)
            {
                chavePrivada = null;
                using (FileStream certificadoStream = new FileStream(arquivoCertificado, FileMode.Open, FileAccess.Read))
                {
                    Pkcs12Store armazemPkcs12 = new Pkcs12Store();
                    armazemPkcs12.Load(certificadoStream, senha.ToCharArray());
    
                    string certificadoCN = armazemPkcs12.Aliases.Cast<string>().FirstOrDefault(n => armazemPkcs12.IsKeyEntry(n));
    
                    //Console.WriteLine("keyAlias => " + certificadoCN);
    
                    chavePrivada = armazemPkcs12.GetKey(certificadoCN).Key;
                    
                    return (X509Certificate)armazemPkcs12.GetCertificate(certificadoCN).Certificate;
                }
            }
        }
    }
