    public static Boolean CheckLicenseSignature(String licXml)
    {
       try
       {
          System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
          xd.LoadXml(licXml);
          String licSig = xd.SelectSingleNode("/License/Signature").InnerText;
          RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
          String rsaPublicKey = "<RSAKeyValue><Modulus>uPCow37yEzlKQXgbqO9E3enSOXY1MCQB4TMbOZyk9eXmc7kuiCMhJRbrwild0LGO8KE3zci9ETBWVVSJEqUqwtZyfUjvWOLHrf5EmzribtSU2e2hlsNoB2Mu11M0SaGd3qZfYcs2gnEnljfvkDAbCyJhUlxmHeI+35w/nqSCjCk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
          rsa.FromXmlString(rsaPublicKey);
          Byte[] licenseData = System.Text.Encoding.UTF8.GetBytes(xd.SelectSingleNode("/License/SignedData").OuterXml);
          return rsa.VerifyData(licenseData, new SHA1CryptoServiceProvider(), Transform(System.Text.Encoding.UTF8.GetBytes(licSig), new FromBase64Transform()));
       }
       catch (System.Xml.XmlException ex)
       {
          return false;
       }
       catch (InvalidOperationException ex)
       {
          return false;
       }
    }
