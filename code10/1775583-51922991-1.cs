    using System;
    using System.Numerics;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace PlayingWithCryptography
    {
        public static class ConvertToRSAParameters
        {
    
            public static string ConvertXML(BigInteger e, BigInteger n)
            {
                var xml = new StringBuilder();
                xml.AppendLine(WrapTags(BigToBase64(n), "Modulus"));
                xml.AppendLine(WrapTags(BigToBase64(e), "Exponent"));
                WrapTags(xml, "RSAKeyValue");
                return xml.ToString();
            }
    
            public static string ConvertXML(BigInteger e, BigInteger n, BigInteger p, BigInteger q,
                                                BigInteger d, BigInteger dp, BigInteger dq, BigInteger inverseQ)
            {
                var xml = new StringBuilder();
                xml.AppendLine(WrapTags(BigToBase64(n), "Modulus"));
                xml.AppendLine(WrapTags(BigToBase64(e), "Exponent"));
                xml.AppendLine(WrapTags(BigToBase64(p), "P"));
                xml.AppendLine(WrapTags(BigToBase64(q), "Q"));
                xml.AppendLine(WrapTags(BigToBase64(d), "D"));
                xml.AppendLine(WrapTags(BigToBase64(dp), "DP"));
                xml.AppendLine(WrapTags(BigToBase64(dq), "DQ"));
                xml.AppendLine(WrapTags(BigToBase64(inverseQ), "InverseQ"));
                WrapTags(xml, "RSAKeyValue");
                return xml.ToString();
    
            }
    
            private static string BigToBase64(BigInteger val)
            {
                var valBytes = val.ToByteArray();
                int len = valBytes.Length;
                while (valBytes[len - 1] == 0)
                {
                    --len;
                    if (len == 0)
                    {
                        break;
                    }
                }
                Array.Resize(ref valBytes, len);
                Array.Reverse(valBytes);
                return System.Convert.ToBase64String(valBytes);
            }
    
            private static string WrapTags(string target, string tag)
            {
                return String.Format("<{0}>{1}</{0}>", tag, target);
            }
    
            private static StringBuilder WrapTags(StringBuilder target, string tag)
            {
                return target.Insert(0, String.Format("<{0}>", tag)).AppendFormat("</{0}>", tag);
            }
            private static void Main(string[] args)
            {
                var msg = "lol";
                var encodedMessage = Encoding.ASCII.GetBytes(msg);
                Console.WriteLine();
                var publicRsa = RSA.Create();
                publicRsa.FromXmlString(
                    ConvertToRSAParameters.ConvertXML(
                        BigInteger.Parse("65537"),
                        BigInteger.Parse("109120132967399429278860960508995541528237502902798129123468757937266291492576446330739696001110603907230888610072655818825358503429057592827629436413108566029093628212635953836686562675849720620786279431090218017681061521755056710823876476444260558147179707119674283982419152118103759076030616683978566631413")
                    )
                );
                var privateRsa = RSA.Create();
                privateRsa.FromXmlString(
                    ConvertToRSAParameters.ConvertXML(
                        BigInteger.Parse("65537"),
                        BigInteger.Parse("109120132967399429278860960508995541528237502902798129123468757937266291492576446330739696001110603907230888610072655818825358503429057592827629436413108566029093628212635953836686562675849720620786279431090218017681061521755056710823876476444260558147179707119674283982419152118103759076030616683978566631413"),
                        BigInteger.Parse("14299623962416399520070177382898895550795403345466153217470516082934737582776038882967213386204600674145392845853859217990626450972452084065728686565928113"),
                        BigInteger.Parse("7630979195970404721891201847792002125535401292779123937207447574596692788513647179235335529307251350570728407373705564708871762033017096809910315212884101"),
                        BigInteger.Parse("46730330223584118622160180015036832148732986808519344675210555262940258739805766860224610646919605860206328024326703361630109888417839241959507572247284807035235569619173792292786907845791904955103601652822519121908367187885509270025388641700821735345222087940578381210879116823013776808975766851829020659073"),
                        BigInteger.Parse("11141736698610418925078406669215087697114858422461871124661098818361832856659225315773346115219673296375487744032858798960485665997181641221483584094519937"),
                        BigInteger.Parse("4886309137722172729208909250386672706991365415741885286554321031904881408516947737562153523770981322408725111241551398797744838697461929408240938369297973"),
                        BigInteger.Parse("5610960212328996596431206032772162188356793727360507633581722789998709372832546447914318965787194031968482458122348411654607397146261039733584248408719418")
                    )
                );
                var encrypted = publicRsa.Encrypt(
                      data: encodedMessage,
                      padding: RSAEncryptionPadding.OaepSHA1);
                var decrypted = privateRsa.Decrypt(
                      data: encrypted,
                      padding: RSAEncryptionPadding.OaepSHA1);
                var decoded = Encoding.ASCII.GetString(decrypted);
               Console.WriteLine(decoded);
                Console.WriteLine("Done!");
            }
        }
    }
