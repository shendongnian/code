    private RulesEngine<IRulesEngine> rulesEngine;
    
    public RulesEngine<IRulesEngine> RulesEngine
    {
        get
        {
            if (null == rulesEngine)
            {
                string rulesPath = Path.Combine(Application.StartupPath, "Rules.cs");
    
                rulesEngine = new RulesEngine<IRulesEngine>(rulesPath, typeof(Rules).FullName);
            }
    
            return rulesEngine;
        }
    }
    
    public IRulesEngine RulesEngineInterface
    {
        get { return RulesEngine.Interface; }
    }
