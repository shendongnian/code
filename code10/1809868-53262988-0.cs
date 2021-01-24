    public virtual int EngineCount => 1;
    public virtual void ReplaceEngine(Engine newEngine, int engineIndex = 0)
    {
        if(engineIndex != 0) throw new ArgumentOutOfRangeException(nameof(engineIndex));
        _engine = newEngine;
    }
