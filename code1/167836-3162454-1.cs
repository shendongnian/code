    /// <summary>
    /// A simple class which can be used to generate "unguessable" verifier values.
    /// </summary>
    public class UnguessableGenerator
    {
        const string AllowableCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789/^()";
        const string SimpleAllowableCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        /// <summary>
        /// Generates an unguessable string sequence of a certain length
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="useSimpleCharacterSet">if set to <c>true</c> [use simple character set].</param>
        /// <returns></returns>
        public static string GenerateUnguessable(int length, bool useSimpleCharacterSet = false, string additionalCharacters = "")
        {
            var random = new Random();
            var chars = new char[length];
            var charsToUse = useSimpleCharacterSet ? SimpleAllowableCharacters : AllowableCharacters;
            charsToUse = string.Format("{0}{1}", charsToUse, additionalCharacters);
            var allowableLength = charsToUse.Length;
            for (var i = 0; i < length; i++)
            {
                chars[i] = charsToUse[random.Next(allowableLength)];
            }
            return new string(chars);
        }
        /// <summary>
        /// Generates an ungessable string, defaults the length to what google uses (24 characters)
        /// </summary>
        /// <returns></returns>
        public static string GenerateUnguessable()
        {
            return GenerateUnguessable(24);
        }
    }
