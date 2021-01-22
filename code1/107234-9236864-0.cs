    private void RegisterEngine<TEngineType>(Func<T> factoryFunc) where TEngineType : Engine
    {
        _knownEngines.Add(typeof(TEngineType), factoryFunc);
    }
 
