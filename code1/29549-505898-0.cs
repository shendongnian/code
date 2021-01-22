    /// <summary>
    /// StringComparer that is basically the same as StringComparer.OrdinalIgnoreCase, except that the hash code function is improved and guaranteed not to change.
    /// </summary>
    public class CaseInsensitiveStringComparer : StringComparer
    {
        /// <summary>
        /// Compares two strings, ignoring case
        /// </summary>
        /// <param name="x">First string</param>
        /// <param name="y">Second string</param>
        /// <returns>Compare result</returns>
        public override int Compare(string x, string y)
        {
            return StringComparer.OrdinalIgnoreCase.Compare(x, y);
        }
        /// <summary>
        /// Checks if two strings are equal, ignoring case
        /// </summary>
        /// <param name="x">First string</param>
        /// <param name="y">Second string</param>
        /// <returns>True if strings are equal, false if not</returns>
        public override bool Equals(string x, string y)
        {
            return Compare(x, y) == 0;
        }
        /// <summary>
        /// Gets a hash code for a string, ignoring case
        /// </summary>
        /// <param name="obj">String to get hash code for</param>
        /// <returns>Hash code</returns>
        public override int GetHashCode(string obj)
        {
            if (obj == null)
            {
                return 0;
            }
            int hashCode = 5381;
            char c;
            for (int i = 0; i < obj.Length; i++)
            {
                c = obj[i];
                if (char.IsLower(c))
                {
                    c = char.ToUpperInvariant(c);
                }
                hashCode = ((hashCode << 5) + hashCode) + c;
            }
            return hashCode;
        }
    }
