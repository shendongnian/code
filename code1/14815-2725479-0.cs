        /// <summary>
        /// Gets array of bytes from memory stream.
        /// </summary>
        /// <param name="stream">Memory stream.</param>
        public static byte[] GetAllBytes(this MemoryStream stream)
        {
            byte[] result = new byte[stream.Length];
            Array.Copy(stream.GetBuffer(), result, stream.Length);
            return result;
        }
