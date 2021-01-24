    public static class Mapper
    {
      public static TupleMapper<TTuple> FromTuple<TTuple>(Expression<Func<TTuple>> tupleSource) where TTuple : struct, ITuple
      {
        if (!(tupleSource.Body is MethodCallExpression call))
        {
          throw new ArgumentException("Argument must be method call returning tuple type", nameof(tupleSource));
        }
        var tupleNamesAttribute = call.Method.ReturnParameter.GetCustomAttribute<TupleElementNamesAttribute>();
        var compiledTupleSource = tupleSource.Compile();
        return new TupleMapper<TTuple>(compiledTupleSource(), tupleNamesAttribute.TransformNames);
      }
    }
    public struct TupleMapper<TTuple> where TTuple : struct, ITuple
    {
      private readonly IList<string> _names;
      private readonly TTuple _tuple;
      public TupleMapper(TTuple tuple, IList<string> names)
      {
        _tuple = tuple;
        _names = names;
      }
      public T Map<T>() where T : new()
      {
        var instance = new T();
        var instanceType = typeof(T);
        for (var i = 0; i < _names.Count; i++)
        {
          var instanceProp = instanceType.GetProperty(_names[i]);
          instanceProp.SetValue(instance, _tuple[i]);
        }
        return instance;
      }
    }
