    public class EncryptionService : Interfaces.IEncryption
	{
		public string Encrypt(string target)
		{
			var key = "-----BEGIN PUBLIC KEY-----\YOURKEY\n-----END PUBLIC KEY-----";
			var rsaProvider = PemKeyUtils.GetRSAProviderFromPemString(key);
			RSAEncyptionManager manager = new RSAEncyptionManager(rsaProvider, RSAEncryptionPadding.Pkcs1);         
     
			return Convert.ToBase64String(manager.Encrypt(target));
		}
	}
 
	public class RSAEncyptionManager {		
		private readonly RSACryptoServiceProvider _serviceProvider;
	    private readonly RSAEncryptionPadding _padding;
		private RSAParameters _rSAKeyInfo;
		public RSAEncyptionManager(RSACryptoServiceProvider serviceProvider, RSAEncryptionPadding padding)
		{			
			_serviceProvider = serviceProvider;
			_padding = padding;
			_rSAKeyInfo = _serviceProvider.ExportParameters(false);
		}
        
		public byte[] Encrypt(string stringToEncrypt)
		{                    			            			                   			
			return _serviceProvider.Encrypt(Encoding.UTF8.GetBytes(stringToEncrypt), _padding);
		}
		public RSAEncyptionManager SetKey(byte[] key) {
			_rSAKeyInfo.Modulus = key;
			_serviceProvider.ImportParameters(_rSAKeyInfo);
			return this ;
		}
	}
