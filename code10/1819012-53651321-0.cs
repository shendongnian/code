            const string publicKey = "MIGJAoGBAMIt95f4xaP7vYV/+Hdyb4DK0oKvw495PrRYG3nsYgVP7zlBE/rTN6Nmt69W9d0nGefuRlJFIr9TA8vlJmqTus6uXEasBuEjzH7vM7HQeAK6i8qEbVy0T+Uuq+16yy059NL7i/VWljVE6rqTntDUELmbIwNBwj6oBuL1z3SnFoMjAgMBAAE="; //generated on iOS
            byte[] publicKeyBytes = Convert.FromBase64String(pKey);
            var stream = new MemoryStream(publicKeyBytes);
            Asn1Object asn1Object = Asn1Object.FromStream(stream);
            Asn1Encodable asn1Sequence = asn1Object;   
            AlgorithmIdentifier algorithmIdentifier = new 
            AlgorithmIdentifier(PkcsObjectIdentifiers.IdRsaesOaep);  
            SubjectPublicKeyInfo subjectPublicKeyInfo = new 
            SubjectPublicKeyInfo(algorithmIdentifier, asn1Sequence);   
            AsymmetricKeyParameter asymmetricKeyParameter2 = 
            PublicKeyFactory.CreateKey(subjectPublicKeyInfo);    
            RsaKeyParameters rsaKeyParameters = 
            (RsaKeyParameters)asymmetricKeyParameter2;
            RSAParameters rsaParameters = new RSAParameters();
            rsaParameters.Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned();
            rsaParameters.Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned();
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(rsaParameters);
            string test = "John snow is the true king";
            byte[] encbyte = rsa.Encrypt(Encoding.UTF8.GetBytes(test), RSAEncryptionPadding.Pkcs1);
            string encrt = Convert.ToBase64String(encbyte);
