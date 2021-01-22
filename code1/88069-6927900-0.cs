    using (Ftp client = new Ftp())
    {
        client.Connect("ftp.example.org");
        client.Login("user", "password");
    
        List<FtpItem> items = client.GetList();
    
        foreach (FtpItem item in items)
        {
            Console.WriteLine("Name:        {0}", item.Name);
            Console.WriteLine("Size:        {0}", item.Size);
            Console.WriteLine("Modify date: {0}", item.ModifyDate);
    
            Console.WriteLine("Is folder:   {0}", item.IsFolder);
            Console.WriteLine("Is file:     {0}", item.IsFile);
            Console.WriteLine("Is symlink:  {0}", item.IsSymlink);
    
            Console.WriteLine();
        }
    
        client.Close();
    }
