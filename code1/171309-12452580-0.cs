        /// <summary>
        /// Splits an array of bytes into a List<byte[]> holding the 
        /// chunks of the original array. If the size of the chunks is bigger than
        /// the array it will return the original array to be split.
        /// </summary>
        /// <param name="array">The array to split</param>
        /// <param name="size">the size of the chunks</param>
        /// <returns></returns>
        public static List<byte[]> SplitArray(byte[] array, int size)
        {
            List<byte[]> chunksList = new List<byte[]>();
            int skipCounter = 0;
            while (skipCounter < array.Length)
            {
                byte[] chunk = array.Skip(skipCounter).Take(size).ToArray<byte>();
                chunksList.Add(chunk);               
                skipCounter += chunk.Length;
            }
            return chunksList;
        }
    }
}
