        public static bool TryOpen(
            string path,
            FileMode fileMode,
            FileAccess fileAccess,
            FileShare fileShare,
            TimeSpan timeout,
            out Stream stream)
        {
            var endTime = DateTime.Now + timeout;
            while (DateTime.Now < endTime)
            {
                if (TryOpen(path, fileMode, fileAccess, fileShare, out stream))
                    return true;
            }
            stream = null;
            return false;
        }
        public static bool TryOpen(
            string path,
            FileMode fileMode,
            FileAccess fileAccess,
            FileShare fileShare,
            out Stream stream)
        {
            try
            {
                stream = File.Open(path, fileMode, fileAccess, fileShare);
                return true;
            }
            catch (IOException e)
            {
                if (!FileIsLocked(e))
                    throw;
                stream = null;
                return false;
            }
        }
        public static bool FileIsLocked(IOException ioException)
        {
            var errorCode = Marshal.GetHRForException(ioException) & ((1 << 16) - 1);
            return errorCode == 32 || errorCode == 33;
        }
