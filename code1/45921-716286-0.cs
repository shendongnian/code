    public TResult Calculate<T, TResult>(Func<T, TResult) action, T input)
    {
      return action(input);
    }
    
    Calculate(i => i * 2); // = 4
