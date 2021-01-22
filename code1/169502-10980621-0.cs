    /// <summary>
    /// <para>This will get the size for a directory</para>
    /// <para>Can be lengthy to complete on complex folder structures</para>
    /// </summary>
    /// <param name="pathToDirectory">The path to the remote directory</param>
    public ulong GetDirectorySize(string pathToDirectory)
    {
        try
        {
            var client = Settings.Variables.FtpClient;
            ulong size = 0;
            if (!IsConnected)
                return 0;
            var dirList = client.GetDirectoryList(pathToDirectory);
            foreach (var item in dirList)
            {
                if (item.IsDirectory)
                    size += GetDirectorySize(string.Format("{0}/{1}", pathToDirectory, item.Name));
                else
                    size += item.Size;
            }
            return size;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return 0;
    }
