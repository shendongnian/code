    public bool IsFileLocked(string filePath, int secondsToWait)
    {
        bool isLocked = true;
        int i = 0;
        while (isLocked &&  ((i < secondsToWait) || (secondsToWait == 0)))
        {
            try
            {
                using (File.Open(filePath, FileMode.Open)) { }
                return false;
            }
            catch (IOException e)
            {
                var errorCode = Marshal.GetHRForException(e) & ((1 << 16) - 1);
                isLocked = errorCode == 32 || errorCode == 33;
                i++;
                if (secondsToWait !=0)
                    new System.Threading.ManualResetEvent(false).WaitOne(1000);
            }
        }
        return isLocked;
    }
    if (!IsFileLocked(file, 10))
    {
        ...
    }
    else
    {
        throw new Exception(...);
    }
