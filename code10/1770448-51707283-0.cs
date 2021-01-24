    public void XXXX(string path)
    {
        string[] directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
    
        directories.ForEach(x=> AddNewFolders(x));
    }
    
    public void AddNewFolders(string path)
    {
          var archivedFoldeer = Path.Combine(path,"Archive");
          if (!Directory.Exists(archivedFoldeer )      
               Directory.CreateDirectory(archivedFoldeer );
          //var notProcesssedFoldeer = Path.Combine(path,"NotProcessed");
    }
