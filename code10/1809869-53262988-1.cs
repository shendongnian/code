    public override int EngineCount => 2;
    public void override ReplaceEngine(Engine newEngine, int engineIndex = 0)
    {
        switch(engineIndex)
        {
            case 1: _secondEngine = newEngine; break;
            default: base.ReplaceEngine(newEngine, engineIndex); break;
        }
    }
