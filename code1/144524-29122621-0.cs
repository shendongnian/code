        /// <summary>
        /// Convert current bytes to string
        /// </summary>
        /// <param name="bytes">Current byte[]</param>
        /// <returns>String version of current bytes</returns>
        public static string StringValue(this byte[] currentBytes)
        {
            return string.Concat(Array.ConvertAll(bytes, b => b.ToString("X2")));
        }
