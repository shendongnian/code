    public IApple
    {
       void Consume();
    }
    
    public IDisposableApple : IApple, IDisposable
    {
    }
