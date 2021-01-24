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
        }
    }
