    using System;
    using System.IO;
    using System.Security.Cryptography;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Security;
    
    namespace ExportToStandardFormats
    {
        class MainClass
        {
    
            public static void Main(string[] args)
            {
                var rsa = new RSACryptoServiceProvider(2048);
                var rsaKeyPair = DotNetUtilities.GetRsaKeyPair(rsa);
                var writer = new StringWriter();
                var pemWriter = new PemWriter(writer);
                pemWriter.WriteObject(rsaKeyPair.Public);
                pemWriter.WriteObject(rsaKeyPair.Private);
                Console.WriteLine(writer);
            }
        }
    }
