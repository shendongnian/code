        -                //var buffer = new char[1024];
        -                string buffer = new string('\0', 1024);
        +                char[] buffer = new char[1024];
        +                //string buffer = new string('\0', 1024);
                         int d;
        -                if ((d = Crypt.CertNameToStr(Crypt.X509Encoding.ASN_Encodings, ref certNameBlob, Crypt.CertNameType.CERT_X500_NAME_STR, ref buffer, 1024 * sizeof(char))) != 0)
        +                if ((d = Crypt.CertNameToStr(Crypt.X509Encoding.ASN_Encodings, ref certNameBlob, Crypt.CertNameType.CERT_X500_NAME_STR, buffer, 1024 * sizeof(char))) != 0)
