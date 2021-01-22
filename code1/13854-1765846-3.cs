    class Program {
      static void Main(string[] args) {
        //Shared 256 bit Key and IV here
        const string sKy = "lkirwf897+22#bbtrm8814z5qq=498j5"; //32 chr shared ascii string (32 * 8 = 256 bit)
        const string sIV = "741952hheeyy66#cs!9hjv887mxx7@8y"; //32 chr shared ascii string (32 * 8 = 256 bit)
        var sTextVal = "Here is my data to encrypt!!!";
        var eText = EncryptRJ256(sKy, sIV, sTextVal);
        var dText = DecryptRJ256(sKy, sIV, eText);
        Console.WriteLine("key: " + sKy);
        Console.WriteLine();
        Console.WriteLine(" iv: " + sIV);
        Console.WriteLine("txt: " + sTextVal);
        Console.WriteLine("encrypted: " + eText);
        Console.WriteLine("decrypted: " + dText);
        Console.WriteLine("press any key to exit");
        Console.ReadKey(true);
      }
      public static string DecryptRJ256(string prm_key, string prm_iv, string prm_text_to_decrypt) {
        var sEncryptedString = prm_text_to_decrypt;
        var myRijndael = new RijndaelManaged() {
          Padding = PaddingMode.Zeros,
          Mode = CipherMode.CBC,
          KeySize = 256,
          BlockSize = 256
        };
        var key = Encoding.ASCII.GetBytes(prm_key);
        var IV = Encoding.ASCII.GetBytes(prm_iv);
        var decryptor = myRijndael.CreateDecryptor(key, IV);
        var sEncrypted = Convert.FromBase64String(sEncryptedString);
        var fromEncrypt = new byte[sEncrypted.Length];
        var msDecrypt = new MemoryStream(sEncrypted);
        var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
        return (Encoding.ASCII.GetString(fromEncrypt));
      }
      public static string EncryptRJ256(string prm_key, string prm_iv, string prm_text_to_encrypt) {
        var sToEncrypt = prm_text_to_encrypt;
        var myRijndael = new RijndaelManaged() {
          Padding = PaddingMode.Zeros,
          Mode = CipherMode.CBC,
          KeySize = 256,
          BlockSize = 256
        };
        var key = Encoding.ASCII.GetBytes(prm_key);
        var IV = Encoding.ASCII.GetBytes(prm_iv);
        var encryptor = myRijndael.CreateEncryptor(key, IV);
        var msEncrypt = new MemoryStream();
        var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
        var toEncrypt = Encoding.ASCII.GetBytes(sToEncrypt);
        csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
        csEncrypt.FlushFinalBlock();
        var encrypted = msEncrypt.ToArray();
        return (Convert.ToBase64String(encrypted));
      }
    }
