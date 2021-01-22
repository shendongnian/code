    [PersistenceMode(PersistenceMode.InnerProperty)]
    [TemplateInstance(TemplateInstance.Single)]
    public ITemplate Template { 
      get { return template; }
      set { template = value; }
    }
