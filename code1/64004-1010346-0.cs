    public static LevelInfo LoadLevel(
        string xmlFile, 
        GraphicsDevice device, 
        PhysicsSimulator sim, 
        ContentManager content)
    {
        FileInfo xmlFileInfo = new FileInfo(xmlFile);
    
        XDocument fileDoc = XDocument.Load(xmlFile);
        //this part is game specific
        LevelInfo levelData = new LevelInfo();
        levelData.DynamicObjects = LevelLoader.LoadDynamicObjects(device, sim, content, xmlFileInfo, fileDoc);
        levelData.StaticObjects = LevelLoader.LoadStaticObjects(device, sim, content, xmlFileInfo, fileDoc);
        levelData.LevelAreas = LevelLoader.LoadAreas(device, xmlFileInfo, fileDoc);
        return levelData;
    }
