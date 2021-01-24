     public class EncryptGUI
        {
            private Aes aes;
    
            public EncryptGUI (byte[] key)
            {
                aes = Aes.Create ();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.None;
                aes.Key = key;
            }
    
            public String encryptUID (byte[] guid)
            {
                ICryptoTransform aesDecryptor = aes.CreateDecryptor ();
                byte[] result = aesDecryptor.TransformFinalBlock (guid, 0, guid.Length);
                return ToHex (result);
            }
    
            public static string ToHex (byte[] data)
            {
                StringBuilder hex = new StringBuilder (data.Length * 2);
                foreach (byte b in data)
                    hex.AppendFormat ("{0:x2}", b);
                return hex.ToString ();
            }
    
            public static void Main (string[] args)
            {
                byte[] key = new byte[16];
                EncryptGUI main = new EncryptGUI (key);
    
                byte[] guid = new byte[16];
                Console.Out.WriteLine (main.encryptUID (guid));
            }
        }
