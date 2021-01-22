    public static void Main()
    {
       Console.WriteLine(GenerateKey());
    }
    public static Byte[] Transform(Byte[] bytes, ICryptoTransform xform)
    {
       using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
       {
          using (CryptoStream cstream = new CryptoStream(stream, xform, CryptoStreamMode.Write))
          {
             cstream.Write(bytes, 0, bytes.Length);
             cstream.Close();
             stream.Close();
             return stream.ToArray();
          }
       }
    }
    public static string GenerateKey()
    {
       RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
       // This is the private key and should never be shared.
       // Generate your own with RSA.Create().ToXmlString(true).
       String rsaPrivateKey = "<RSAKeyValue><Modulus>uPCow37yEzlKQXgbqO9E3enSOXY1MCQB4TMbOZyk9eXmc7kuiCMhJRbrwild0LGO8KE3zci9ETBWVVSJEqUqwtZyfUjvWOLHrf5EmzribtSU2e2hlsNoB2Mu11M0SaGd3qZfYcs2gnEnljfvkDAbCyJhUlxmHeI+35w/nqSCjCk=</Modulus><Exponent>AQAB</Exponent><P>4SMSdNcOP0qAIoT2qzODgyl5yu9RubpIU3sSqky+85ZqJHXLUDjlgqAZvT71ROexJ4tMfMOgSWezHQwKWpz3sw==</P><Q>0krr7cmorhWgwCDG8jmzLMo2jafAy6tQout+1hU0bBKAQaPTGGogPB3hTnFIr84kHcRalCksI6jk4Xx/hiw+sw==</Q><DP>DtR9mb60zIx+xkdV7E8XYaNwx2JeUsqniwA3aYpmpasJ0N8FhoJI9ALRzzp/c4uDiuRNJIbKXyt6i/ZIFFH0qw==</DP><DQ>mGCxlBwLnhkN4ind/qbQriPYY8yqZuo8A9Ggln/G/IhrZyTOUWKU+Pqtx6lOghVdFjSxbapn0W8QalNMFGz7AQ==</DQ><InverseQ>WDYfqefukDvMhPHqS8EBFJFpls/pB1gKsEmTwbJu9fBxN4fZfUFPuTnCIJsrEsnyRfeNTAUFYl3hhlRYZo5GiQ==</InverseQ><D>qB8WvAmWFMW67EM8mdlReI7L7jK4bVf+YXOtJzVwfJ2PXtoUI+wTgH0Su0IRp9sR/0v/x9HZlluj0BR2O33snQCxYI8LIo5NoWhfhkVSv0QFQiDcG5Wnbizz7w2U6pcxEC2xfcoKG4yxFkAmHCIkgs/B9T86PUPSW4ZTXcwDmqU=</D></RSAKeyValue>";
       rsa.FromXmlString(rsaPrivateKey);
       String signedData = "<SignedData><Key>Insert your key here</Key></SignedData>";
       Byte[] licenseData = System.Text.Encoding.UTF8.GetBytes(signedData);
       Byte[] sigBytes = rsa.SignData(licenseData, new SHA1CryptoServiceProvider());
       String sigText = System.Text.Encoding.UTF8.GetString(Transform(sigBytes, new ToBase64Transform()));
       System.Text.StringBuilder sb = new StringBuilder();
       using (System.Xml.XmlWriter xw = System.Xml.XmlTextWriter.Create(sb))
       {
          xw.WriteStartElement("License");
          xw.WriteRaw(signedData);
          xw.WriteElementString("Signature", sigText);
          xw.WriteEndElement();
       }
       return sb.ToString();
    }
