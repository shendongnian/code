    public class Factory
    {
      Dictionary<Type, Type> typeMapping = new Dictionary<Type, Type>();
    
      public void Register<IType, CType>()
      {
        typeMapping.Add(typeof(IType),typeof(CType));
      }
    
      public IType Create<IType>()
      {
        Activator.CreateInstance(typeMapping[typeof(IType)]);
      }
    }
