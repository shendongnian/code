    public string MigrateProject(int fileVersion, int plugInversion, string proj)
    {
        if(fileVersion>plugInversion)
        {
           //tell user to upgrade their copy of the plugin
           return null;
        }
    
        //user already at max version
        if(fileVersion >= (myMigrateMethods.Length-1)) return null;
        var firstMigrateMethodNeeded = (fileVersion-1); //array is 0-based
        var output = serializedProject;
        for(var i= firstMigrateMethodNeeded; i< myMigrateMethods.Length; i++)
        {
           output = myMigrateMethods[i](output);
        }
        return output;
    
    }
