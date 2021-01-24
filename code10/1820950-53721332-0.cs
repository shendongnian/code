    namespace VPV.Helpers {    
        public static class Strings {    
            public string Encrypt(string val, string salt) {
                byte[] data = Encoding.UTF8.GetBytes(val + salt);
                data = SHA512.Create().ComputeHash(data);
                return Convert.ToBase64String(data);
            }
        }
    }
