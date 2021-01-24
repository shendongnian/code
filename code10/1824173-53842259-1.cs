      public static bool IsFileClosed(string filepath)
      {
            bool fileClosed = false;
            int retries = 20;
            const int delay = 400; // set a delay period = retries*delay milliseconds
            if (!File.Exists(filepath))
                return false;
            do
            {
                try
                {
                    // Attempts to open then close the file in RW mode, denying other users to place any locks.
                    FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                    fs.Close();
                    fileClosed = true; // success
                }
                catch (IOException) { }
                retries--;
                if (!fileClosed)
                    Thread.Sleep(delay);
            }
            while (!fileClosed && retries > 0);
            return fileClosed;
        }
