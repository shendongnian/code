    using System;
    using System.Collections.Generic;
    using Org.BouncyCastle.Crypto.Paddings;
    using System.Text;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.Utilities.Encoders;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Crypto;
     
    public class Decrypt
    {  
     
    public string Decryption(string Request)
    {
             	String EncryptedS = Request;
     
             	string convertHTML = string.Empty;
    String key = ConfigurationSettings.AppSettings["EncDecKey"];//"123456789";
     
    byte[] keyByte = Encoding.UTF8.GetBytes(key);   
    try
    {
    byte[] result = BouncyCastleCrypto(false, UrlBase64.Decode(EncryptedS), key);
    convertHTML = Encoding.UTF8.GetString(result);
    }
    catch (Org.BouncyCastle.Crypto.CryptoException ex)
    {
    convertHTML = "false";
                   
    }
     
    return convertHTML;
    }
     
    private byte[] BouncyCastleCrypto(bool forEncrypt, byte[] input, string key)
    {
    try
    {
    byte[] keyByte = Encoding.UTF8.GetBytes(key);
    _PaddedBufferedBlockCipherWithlowfish.Init(forEncrypt, new KeyParameter(keyByte));
    byte[] outBytes = new byte[_PaddedBufferedBlockCipherWithlowfish.GetOutputSize(input.Length)];
    int len = _PaddedBufferedBlockCipherWithlowfish.ProcessBytes(input, 0, input.Length, outBytes, 0);
    _PaddedBufferedBlockCipherWithlowfish.DoFinal(outBytes, len);
    return outBytes;
     
    }
    catch (Org.BouncyCastle.Crypto.CryptoException ex)
    {
    throw new CryptoException(ex.ToString());
    }
    }     
    }
     
    
