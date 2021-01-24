    private class FilePaths {
        public FilePaths(string inputPath, string outputPath) { 
            InputPath = inputPath;
            OutputPath = outputPath;
        }
        public string InputPath {get; set; } = string.Empty;
        public string OutputPath {get; set; } = string.Empty;
    }
    enum InventoryTypeEnum {
        Prices,
        Licences
    }
    private const string PRICEFILE = "Resources\\prices.xml";
    private const string RATEFILE = "Resources\\rates.xml";
    private const string INPUTFILE = "Resources\\ItemsList.txt";
    private const string INPUTFILELICENSE = "Resources\\Licenses.txt";
    private const string LICENSEFILE = "Resources\\Licenses.xml";
    private Dictionary<bool, Dictionary<InventoryTypeEnum, FilePaths>> _pathMap = 
        new Dictionary<bool, Dictionary<InventoryTypeEnum, FilePaths>>() {
            { true, { InventoryTypeEnum.Prices, 
                      new FilePaths(
                          ApplicationDeployment.CurrentDeployment.DataDirectory + @"\" + INPUTFILE,
                          ApplicationDeployment.CurrentDeployment.DataDirectory + @"\" + PRICEFILE
                      ) 
            } },
            { true, { InventoryTypeEnum.Licences, 
                      new FilePaths(
                          ApplicationDeployment.CurrentDeployment.DataDirectory + @"\" + INPUTFILELICENSE,
                          ApplicationDeployment.CurrentDeployment.DataDirectory + @"\" + LICENSEFILE
                      ) 
            } },
            { false, { InventoryTypeEnum.Prices, 
                      new FilePaths(
                          INPUTFILE,
                          PRICEFILE
                      ) 
            } },
            { false, { InventoryTypeEnum.Licenses, 
                      new FilePaths(
                          INPUTFILELICENSE,
                          LICENSEFILE
                      ) 
            } }
        }
    public string getFromInventoryTableOnServer(InventoryTypeEnum type) {
        FilePaths paths = _pathMap[ApplicationDeployment.IsNetworkDeployed][type];
        // paths.InputPath and paths.OutputPath should now hold the correct values.
        //  ... rest of function ...
    }
