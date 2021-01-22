    public class RandomStringGenerator
    {
        public static string Gen()
        {
            return ConvertToBase(DateTime.UtcNow.ToFileTimeUtc()) + GenRandomStrings(5); //keep length fixed at least of one part
        }
        private static string GenRandomStrings(int strLen)
        {
            var result = string.Empty;
            var Gen = new RNGCryptoServiceProvider();
            var data = new byte[1];
            
            while (result.Length < strLen)
            {
                Gen.GetNonZeroBytes(data);
                int code = data[0];
                if (code > 48 && code < 57 || // 0-9
                    code > 65 && code < 90 || // A-Z
                    code > 97 && code < 122   // a-z
                    )
                {
                    result += Convert.ToChar(code);
                }
            }
            
            return result;
        }
        private static string ConvertToBase(long num, int nbase = 36)
        {
            var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //if you wish make algoritm more secure - change order of letter here
            // check if we can convert to another base
            if (nbase < 2 || nbase > chars.Length)
                return null;
            int r;
            var newNumber = string.Empty;
            // in r we have the offset of the char that was converted to the new base
            while (num >= nbase)
            {
                r = (int) (num % nbase);
                newNumber = chars[r] + newNumber;
                num = num / nbase;
            }
            // the last number to convert
            newNumber = chars[(int)num] + newNumber;
            return newNumber;
        }
    }
