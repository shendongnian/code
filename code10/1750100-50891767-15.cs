    public string GetFromInventoryTableOnServer(InventoryTypeEnum type)
    {
        var key = new Key(type, ApplicationDeployment.IsNetworkDeployed);
        FilePaths paths = _pathsDictionary[key];
        // remaining code here ...
    }
