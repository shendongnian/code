        /// <summary>
        /// Binary comparison of two files
        /// </summary>
        /// <param name="fileName1">the file to compare</param>
        /// <param name="fileName2">the other file to compare</param>
        /// <returns>a value indicateing weather the file are identical</returns>
        public static bool CompareFiles(string fileName1, string fileName2)
        {
            FileInfo info1 = new FileInfo(fileName1);
            FileInfo info2 = new FileInfo(fileName2);// should be fileName2, not fileName1
            bool same = info1.Length == info2.Length;
            if (same)
            {
                using (FileStream fs1 = info1.OpenRead())
                using (FileStream fs2 = info2.OpenRead())
                using (BufferedStream bs1 = new BufferedStream(fs1))
                using (BufferedStream bs2 = new BufferedStream(fs2))
                {
                    for (long i = 0; i < info1.Length; i++)
                    {
                        if (bs1.ReadByte() != bs2.ReadByte())
                        {
                            same = false;
                            break;
                        }
                    }
                }
            }
            return same;
        }
