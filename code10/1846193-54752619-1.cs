    partial class USERSController
    {    
        /// <summary>
        /// Called to generate salt byte array.
        /// </summary>
        /// <returns>The generated salt byte array.</returns>
        public static byte[] GenerateSalt()
        {
            byte[] iv;
            using (var alg = new AesCryptoServiceProvider())
            {
                alg.BlockSize = 128; //block size is 8bytes, which is the the size of the IV generated.
                alg.KeySize = 256; //key size is 32bytes
                alg.GenerateIV();
                iv = alg.IV;
            }
            
            return iv;
        }
        /// <summary>
        /// Called to hash a user password to be stored in DB.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <param name="salt">The IV used to salt the password before it is hashed.</param>
        /// <param name="errorDesc">Returns an error description if an error occurs.</param>
        /// <returns>Returns the hashed password as a HEX string on success, otherwise returns null.</returns>
        private static string HashPassword(string password, byte[] salt, ref string errorDesc)
        {
            try
            {
                byte[] newPassword = Encoding.ASCII.GetBytes(password.ToUpper());
                if (salt != null && salt.Length > 0)
                {
                    int count = (salt.Length < newPassword.Length) ? salt.Length : newPassword.Length;
                    byte[] temp = new byte[salt.Length + newPassword.Length];
                    for (int index = 0; index < count; index++)
                    {
                        temp[index * 2] = newPassword[index];
                        temp[index * 2 + 1] = salt[index];
                    }
                    if (count == salt.Length && count < newPassword.Length)
                        Buffer.BlockCopy(newPassword, count, temp, count * 2, newPassword.Length - count);
                    else if (count == newPassword.Length && count < salt.Length)
                        Buffer.BlockCopy(salt, count, temp, count * 2, salt.Length - count);
                    newPassword = temp;
                }
                using (var hash = new System.Security.Cryptography.SHA1CryptoServiceProvider())
                {
                    hash.ComputeHash(newPassword);
                    return GetHexStringFromBytes(hash.Hash);
                }
            }
            catch (Exception Ex)
            {
                errorDesc = Ex.Message;
                if (Ex.InnerException != null) errorDesc = string.Format("{0}\r\n{1}", errorDesc, Ex.InnerException.Message);
            }
            return null;
        }
        /// <summary>
        /// called to convert byte data into hexidecimal string were each byte is represented as two hexidecimal characters.
        /// </summary>
        /// <param name="data">Byte data to convert.</param>
        /// <returns>A hexidecimal string version of the data.</returns>
        private static string GetHexStringFromBytes(byte[] data)
        {
            if (data == null || data.Length == 0) return string.Empty;
            StringBuilder sbHex = new StringBuilder();
            for (int index = 0; index < data.Length; index++) sbHex.AppendFormat(null, "{0:X2}", data[index]);
            return sbHex.ToString();
        }
        /// <summary>
        /// called to convert hexidecimal string into byte data were two hexidecimal characters are converted into a byte.
        /// </summary>
        /// <param name="hexString">A hexidecimal string to convert</param>
        /// <returns>The converted byte data.</returns>
        private static byte[] GetBytesFromHexString(string hexString)
        {
            if (string.IsNullOrEmpty(hexString)) return null;
            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                data[index] = byte.Parse(hexString.Substring(index * 2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            return data;
        }       
    }
