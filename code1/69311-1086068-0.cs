    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml;
    public static class Program {
        public static void Main() {
            if (!File.Exists("PublicKey.key")) {
                // Assume first run, generate keys and sign document.
                ServerMethods.GenerateKeyPair();
                var input = new XmlDocument();
                input.Load("input.xml");
                Debug.Assert(input.DocumentElement != null);
                var licNode = input.DocumentElement["lic"];
                Debug.Assert(licNode != null);
                var licNodeXml = licNode.OuterXml;
                var signedNode = input.CreateElement("signature");
                signedNode.InnerText = ServerMethods.CalculateSignature(licNodeXml);
                input.DocumentElement.AppendChild(signedNode);
                input.Save("output.xml");
            }
            if (ClientMethods.IsValidLicense("output.xml")) {
                Console.WriteLine("VALID");
            } else {
                Console.WriteLine("INVALID");
            }
        }
        public static class ServerMethods {
            public static void GenerateKeyPair() {
                var rsa = SharedInformation.CryptoProvider;
                using (var keyWriter = File.CreateText("PublicKey.key"))
                    keyWriter.Write(rsa.ToXmlString(false));
                using (var keyWriter = File.CreateText("PrivateKey.key"))
                    keyWriter.Write(rsa.ToXmlString(true));
            }
            public static string CalculateSignature(string data) {
                var rsa = SharedInformation.CryptoProvider;
                rsa.FromXmlString(File.ReadAllText("PrivateKey.key"));
                var dataBytes = Encoding.UTF8.GetBytes(data);
                var signatureBytes = rsa.SignData(dataBytes, SharedInformation.HashAlgorithm);
                return Convert.ToBase64String(signatureBytes);
            }
        }
        public static class ClientMethods {
            public static bool IsValid(string data, string signature) {
                var rsa = SharedInformation.CryptoProvider;
                rsa.FromXmlString(File.ReadAllText("PublicKey.key"));
                var dataBytes = Encoding.UTF8.GetBytes(data);
                var signatureBytes = Convert.FromBase64String(signature);
                return rsa.VerifyData(dataBytes, SharedInformation.HashAlgorithm, signatureBytes);
            }
            public static bool IsValidLicense(string filename) {
                var doc = new XmlDocument();
                doc.Load(filename);
                var licNode = doc.SelectSingleNode("/root/lic") as XmlElement;
                var signatureNode = doc.SelectSingleNode("/root/signature") as XmlElement;
                if (licNode == null || signatureNode == null) return false;
                return IsValid(licNode.OuterXml, signatureNode.InnerText);
            }
        }
        public static class SharedInformation {
            public static int KeySize {
                get { return 1024; }
            }
            public static string HashAlgorithm {
                get { return "SHA512"; }
            }
            public static RSACryptoServiceProvider CryptoProvider {
                get { return new RSACryptoServiceProvider(KeySize, new CspParameters()); }
            }
        }
    }
