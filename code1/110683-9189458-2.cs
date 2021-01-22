    public static class BaseTypeFactory
    {
       private delegate BaseType BaseTypeConstructor(int pParam1, int pParam2);
       
       private static readonly Dictionary<Type, BaseTypeConstructor>
       mTypeConstructors = new Dictionary<Type, BaseTypeConstructor>
       {
          { typeof(Object1), (pParam1, pParam2) => new Object1(pParam1, pParam2) },
          { typeof(Object2), (pParam1, pParam2) => new Object2(pParam1, pParam2) },
          { typeof(Object3), (pParam1, pParam2) => new Object3(pParam1, pParam2) }
       };
