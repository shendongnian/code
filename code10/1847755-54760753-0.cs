    public class KeyGenerator
            {
                public static string GetUniqueKey()
                {
                    int size = 6;
                    char[] chars =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                    byte[] data = new byte[size];
                    using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
                    {
                        crypto.GetBytes(data);
                    }
    
                    StringBuilder result = new StringBuilder(size);
                    foreach (byte b in data)
                    {
                        result.Append(chars[b % (chars.Length)]);
                    }
    
                    var ExpiryDate = DateTime.Now;
                    // before returning store it to somewhere along with user unique id to verify later.. 
                    // maybe user id is string 
                    return result.ToString();
                }
    
                public static bool IsValidKey(string UserId)
                {
                    // first get the Key and saved DateTime..
                    // lets assume ExpDate is DateTime object that was saved..
                    var Now = DateTime.Now;
                    if (DateTime.Compare(Now, ExpDate) <= 0)
                    {
                        // Now is earlier or exact ExpDate, we've saved earlier
                        // key is still valid 
                        // handle this scenario 
                       return true;
                    }
                    return false;
                }
            }
