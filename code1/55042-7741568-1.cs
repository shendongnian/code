        /// <summary>
        /// This will convert a hex-encoded string to byte data
        /// </summary>
        /// <param name="hexData">The hex-encoded string to convert</param>
        /// <returns>The bytes that make up the hex string</returns>
        public static byte[] FromHex(string hexData)
        {
            List<byte> data = new List<byte>();
            string byteSet = string.Empty;
            int stringLen = hexData.Length;
            int length = 0;
            for (int i = 0; i < stringLen; i = i + 2)
            {
                length = (stringLen - i) > 1 ? 2 : 1;
                byteSet = hexData.Substring(i, length);
                // try and parse the data
                data.Add(Convert.ToByte(byteSet, 16 /*base*/));
            } // next set
            return data.ToArray();
        }
