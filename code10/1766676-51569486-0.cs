    public interface IParentGenericClass<out TObject> where TObject : ITypeInterface
    {
    }
    public class ParentGenericClass<TObject> : IParentGenericClass<TObject>
    where TObject : ITypeInterface
    {
    }
    ...
    var result = new List<IParentGenericClass<ITypeInterface>>();
    result.Add(first);
