        /// <summary>
        /// Turns the byte array into its Hex representation.
        /// </summary>
        public static string ToHex(this byte[] y)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in y)
            {
                sb.Append(b.ToString("X").PadLeft(2, "0"[0]));
            }
            return sb.ToString();
        }
