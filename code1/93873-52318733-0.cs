    using System.Xml.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Linq;
    /// <summary>
    /// Provides a way to easily compute SHA256 hash strings for XML objects.
    /// </summary>
    public static class XMLHashUtils
    {
        /// <summary>
        /// Precompute a hexadecimal lookup table for runtime performance gain, at the cost of memory and startup performance loss.
        /// SOURCE: https://stackoverflow.com/a/18574846
        /// </summary>
        static readonly string[] hexLookupTable = Enumerable.Range(0, 256).Select(integer => integer.ToString("x2")).ToArray();
        static readonly SHA256Managed sha256 = new SHA256Managed();
        /// <summary>
        /// Computes a SHA256 hash string from an XElement and its children.
        /// </summary>
        public static string Hash(XElement xml)
        {
            string xmlString = xml.ToString(SaveOptions.DisableFormatting); // Outputs XML as single line
            return Hash(xmlString);
        }
        /// <summary>
        /// Computes a SHA256 hash string from a string.
        /// </summary>
        static string Hash(string stringValue)
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringValue));
            return BytesToHexString(hashBytes);
        }
        /// <summary>
        /// Converts a byte array to a hexadecimal string using a lookup table.
        /// </summary>
        static string BytesToHexString(byte[] bytes)
        {
            int length = bytes.Length;
            StringBuilder sb = new StringBuilder(length * 2); // Capacity fits hash string length
            for (var i = 0; i < length; i++)
            {
                sb.Append(hexLookupTable[bytes[i]]); // Using lookup table for faster runtime conversion
            }
            return sb.ToString();
        }
    }
