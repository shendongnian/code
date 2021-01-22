    public class FileCompare
    {
        public static bool FilesEqual(string fileName1, string fileName2)
        {
            return FilesEqual(new FileInfo(fileName1), new FileInfo(fileName2));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="bufferSize">8kb seemed like a good default</param>
        /// <returns></returns>
        public static bool FilesEqual(FileInfo file1, FileInfo file2, int bufferSize = 8192)
        {
            if (!file1.Exists || !file2.Exists || file1.Length != file2.Length) return false;
            var buffer1 = new byte[bufferSize];
            var buffer2 = new byte[bufferSize];
            using (var stream1 = file1.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var stream2 = file2.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    while (true)
                    {
                        var bytesRead1 = stream1.Read(buffer1, 0, bufferSize);
                        var bytesRead2 = stream2.Read(buffer2, 0, bufferSize);
                        if (bytesRead1 != bytesRead2) return false;
                        if (bytesRead1 == 0) return true;
                        if (!ArraysEqual(buffer1, buffer2, bytesRead1)) return false;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <param name="bytesToCompare"> 0 means compare entire arrays</param>
        /// <returns></returns>
        public static bool ArraysEqual(byte[] array1, byte[] array2, int bytesToCompare = 0)
        {
            if (array1.Length != array2.Length) return false;
            var length = (bytesToCompare == 0) ? array1.Length : bytesToCompare;
            var tailIdx = length - length % sizeof(Int64);
            
            //check in 8 byte chunks
            for (var i = 0; i < tailIdx; i += sizeof(Int64))
            {
                if (BitConverter.ToInt64(array1, i) != BitConverter.ToInt64(array2, i)) return false;
            }
            
            //check the remainder of the array, always shorter than 8 bytes
            for (var i = tailIdx; i < length; i++)
            {
                if (array1[i] != array2[i]) return false;
            }
            return true;
        }
    }
