        /// <summary>
        /// return the detected encoding and the contents of the file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contents"></param>
        /// <returns></returns>
        public static Encoding DetectEncoding(String fileName, out String contents)
        {
            // open the file with the stream-reader:
            using (StreamReader reader = new StreamReader(fileName, true))
            {
                // read the contents of the file into a string
                contents = reader.ReadToEnd();
                // return the encoding.
                return reader.CurrentEncoding;
            }
        }
 
