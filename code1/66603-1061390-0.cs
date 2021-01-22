    public void GetFileNames(string servername, string databasename)
    {
        Server s = new Server(servername);
        foreach (FileGroup fg in s.Databases[databasename].FileGroups)
        {
            foreach (DataFile df in fg.Files)
                Console.WriteLine(df.FileName);
        }
    }
