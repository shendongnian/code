    class Folder  // could be converted to a DataRow-derivative
    {
        public int Id          { get; set; }
        public string Name     { get; set; }
        public int? ParentId   { get; set; }
        public IEnumerable<Folder> GetChildren( IEnumerable<Folder> allFolders )
        {
            // NOTE: becomes expensive on large hierarchies on unindexed data
            //   a slightly better version, could replace IEnumerable<Folder>
            //   with IOrderedEnumerable<Folder> which would allow the use of
            //   a binary search algorithm for finding children (assuming it's
            //   ordered on the ParentId property).
            return AllFolders.Where( x => x.ParentId.HasValue && 
                                          x.ParentId.Value = this.Id );
        }
    }
    // elsewhere in your code...
    void LoadAndPrintFolders()
    {
       // load the folder data... from database, or wherever
       IEnumerable<Folder> allFolders = LoadFolders();
       
       // find all root folders (let's say, those that have a null ParentId
       IEnumerable<Folder> rootFolders = 
              allFolders.Where( x => !x.ParentId.HasValue );
       // iterate over all of the data as a tree structure...
       foreach( var folder in rootFolders )
       {
           PrintFolder( allFolders, folder, 0 );
       }
       
    }
    // recursive function to print all folders...
    void PrintFolder( IEnumerable<Folder> allFolders, Folder f, int level )
    {
        Console.WriteLine( "{0}{1}", new string('\t',level), f.Name );
        foreach( var folder in f.GetChildren( allFolders )
        {
            PrintFolder( allFolders, folder, level + 1 );
        }
    }
