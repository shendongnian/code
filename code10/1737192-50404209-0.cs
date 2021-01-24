    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    namespace Test
    {
        /// <summary>
        /// Extension methods for hashing strings
        /// </summary>
        public static class HashExtensions
        {
            /// <summary>
            /// Creates a SHA256 hash of the specified input.
            /// </summary>
            /// <param name="input">The input.</param>
            /// <returns>A hash</returns>
            public static string Sha256(this string input)
            {
                if (!string.IsNullOrEmpty(input))
                {
                    using (var sha = SHA256.Create())
                    {
                        var bytes = Encoding.UTF8.GetBytes(input);
                        var hash = sha.ComputeHash(bytes);
                        return Convert.ToBase64String(hash);
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
