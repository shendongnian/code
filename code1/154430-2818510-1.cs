    private Dictionary<Type, Action<I>> _mapping = new Dictionary<Type, Action<I>>
    { 
      { typeof(A), i => MethodA(i as A)},
      { typeof(B), i => MethodB(i as B)},
      { typeof(C), i => MethodC(i as C)},
    };
    
    private void ExecuteBasedOnType(object value)
    {
        if(_mapping.ContainsKey(value.GetType()))
           _mapping(value.GetType())(value as I);
    }
