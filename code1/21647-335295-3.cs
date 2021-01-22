    public string Encrypt(string public_key,string exponent, string data)
    {
        rsa = new RSACryptoServiceProvider(); 
        rsa.FromXmlString(String.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",public_key,exponent));
        byte[] plainbytes = System.Text.Encoding.UTF8.GetBytes(data);
        byte[] cipherbytes = rsa.Encrypt(plainbytes,false);
        return Convert.ToBase64String(cipherbytes);
    }
