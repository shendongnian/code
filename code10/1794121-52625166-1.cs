    [System.Serializable]
    public class Folder
    {
        // Supposing you have the name of the folder instead of its path
        // Otherwise, you just have to check if the paths are equals
        public string Name;
        public List<Folder> Folders; // Folder instead of string
        public List<File> Files;
    }
    
    public bool Exists( string path )
    {
        string[] hierarchy = path.Split('\\');
    
        List<Folder> folders = GetRootFolders() ; // assume it's already populated
    
        for( int i = 0 ; i < hierarchy.Length ; ++i )
        {
            if( folders == null || folders.Count == 0 )
                return false ;
            Folder desiredFolder = folders.Find( f => f.Name.Equals( hierarchy[i] ));
            if( desiredFolder == null )
                return false ;
            folders = desiredFolder.Folders;
        }
        return true;
    }
