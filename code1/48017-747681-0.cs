    public static byte[] CalcDesMac(byte[] key, byte[] data){
    		DESCryptoServiceProvider des = new DESCryptoServiceProvider();
    		des.Key = key;
    		des.IV = new byte[8];
    		des.Padding = PaddingMode.Zeros;
    		MemoryStream ms = new MemoryStream();
    		using(CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write)){
    		  cs.Write(data, 0, data.Length);
    		}
    		byte[] encryption = ms.ToArray();
    		byte[] mac = new byte[8];
    		Array.Copy(encryption, encryption.Length-8, mac, 0, 8);
    		PrintByteArray(encryption);
    		return mac;
    	}
