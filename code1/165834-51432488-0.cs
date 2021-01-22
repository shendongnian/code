    public delegate void SmartAction<T>(SmartAction<T> self, T data);
    
    public event SmartAction<int> ProgressChanged;
    
    ProgressChanged += (self, progress) => 
    { 
      Console.WriteLine(progress);
      ProgressChanged -= self;
    };
