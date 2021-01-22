    public List<TextFileInfo> GetFiles() {
      var list = new List<TextFileInfo>();
      
      var config = TextFileConfigurationSection.GetInstance();
      if (config == null)
        return list;
        
      foreach (TextFileConfigurationElement fileConfig in config.Files) {
        list.Add(new TextFileInfo 
                            {
                              Name = fileConfig.Name,
                              TextFilePath = fileConfig.TextFilePath,
                              XmlFilePath = fileConfig.XmlFilePath
                             });
        
      }
      return list;
    }
    
