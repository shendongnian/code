    Type SpecifyObjectArgs(Type sample) {
      var types = new Type[sample.GetGenericArguments().Length];
      for(int i = 0; i < types.Length; i++) types[i] = typeof(System.Object);
      return sample.MakeGenericType(types);
    }
    
    var baseWithObjs = SpecifyObjectArgs(baseType);
    var sampleWithObjs = SpecifyObjectArgs(sampleType.GetGenericTypeDefinition());
    baseWithObjs.IsAssignableFrom(sampleWithObjs);
