    var listGenericParameter = typeof(ClassName);
    var listObjectType = typeof(List<>);
    var constructedListObjectType = listObjectType.MakeGenericType(listGenericParameter);
    var listInstance = Activator.CreateInstance(constructedListObjectType);
    var constructedEnumerableType = typeof(IEnumerable<>).MakeGenericType(listGenericParameter);
    var asQueryableMethod = typeof(Queryable).GetMethod(nameof(Queryable.AsQueryable), new[] { constructedEnumerableType }) ??
          throw new InvalidOperationException($"Could not find method {nameof(Queryable.AsQueryable)} on type {nameof(Queryable)}");
    var listAsQueryable = asQueryableMethod.Invoke(null, new [] { listInstance });
    public class ClassName { }
