    public static string GetTextFromResource(string keyValue)
            {
                var path = "ProjectName.Folder.pl";
    
                var res_manager = new ResourceManager(path, typeof(pl).Assembly);
    
                return res_manager.GetString(keyValue);
            }
