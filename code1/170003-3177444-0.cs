    public void GetFoo(string guid)
    {
         string sqlGuid = guid.ToString().Trim().Replace("-", "");
    
         var d = from status in dc.FolderStatus.Where(status => status.Date <= DateTime.Now &&
                                                                status.Folder.TapeCode == sqlGuid);
    }
