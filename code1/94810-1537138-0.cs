    public IEnumerable<ModuleData> ListModules()
    {
        if (Modules == null)
        {
            Modules = Source.Descendants("Module")
                          .Select(m => new ModuleData(m.Element("ModuleID").Value, 1, 1)))
                          .ToList();
        }
        return Modules;
    }
