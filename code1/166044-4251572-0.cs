    Sftp sftp = new Sftp(serverUri.Host, userName, password);
    
    sftp.Connect();
    
    //the foldername cannot be empty, or the listing will not show
    ArrayList res = sftp.GetFileList("/foldername");
    foreach (var item in res)
    {
        if (item.ToString() != "." && item.ToString() != "..")
            Console.WriteLine(item.ToString());
    }
    
    sftp.Close();
