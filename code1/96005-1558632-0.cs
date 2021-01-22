    public static void FileMove(string src, ref string dest, bool overwrite)
    {
        if (File.Exists(src))
        {
            File.SetAttributes(src, FileAttributes.Normal);
            string destinationDir = Path.GetDirectoryName(dest);
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }
            try
            {
                File.Move(src, dest);
            }
            catch (Exception)
            {
                int errorCode = Marshal.GetLastWin32Error();
                //183 - Невозможно создать файл, так как он уже существует.
                if (errorCode != 183)
                    throw;
                if (overwrite)
                {
                    File.SetAttributes(dest, FileAttributes.Normal);
                    File.Delete(dest);
                    File.Move(src, dest);
                }
                else
                {
                    string name = Path.GetFileNameWithoutExtension(dest);
                    string ext = Path.GetExtension(dest);
                    int i = 0;
                    do
                    {
                        dest = Path.Combine(destinationDir, name 
                            + ((int)i++).ToString("_Copy(#);_Copy(#);_Copy") + ext);
                    }
                    while (File.Exists(dest));
                    File.Move(src, dest);
                }
        }
    }
