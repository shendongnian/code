        public static bool AreFileSystemObjectsEqual(string dirName1, string dirName2)
        {
            //Optimization: if strings are equal, don't bother with the IO
            bool bRet = string.Equals(dirName1, dirName2, StringComparison.OrdinalIgnoreCase);
            if (!bRet)
            {
                //NOTE: we cannot lift the call to GetFileHandle out of this routine, because we _must_
                // have both file handles open simultaneously in order for the objectFileInfo comparison
                // to be guaranteed as valid.
                using (SafeFileHandle directoryHandle1 = GetFileHandle(dirName1), directoryHandle2 = GetFileHandle(dirName2))
                {
                    BY_HANDLE_FILE_INFORMATION? objectFileInfo1 = GetFileInfo(directoryHandle1);
                    BY_HANDLE_FILE_INFORMATION? objectFileInfo2 = GetFileInfo(directoryHandle2);
                    bRet = objectFileInfo1 != null
                           && objectFileInfo2 != null
                           && (objectFileInfo1.Value.FileIndexHigh == objectFileInfo2.Value.FileIndexHigh)
                           && (objectFileInfo1.Value.FileIndexLow == objectFileInfo2.Value.FileIndexLow)
                           && (objectFileInfo1.Value.VolumeSerialNumber == objectFileInfo2.Value.VolumeSerialNumber);
                }
            }
            return bRet;
        }
