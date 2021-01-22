    public class BaseType { }
    public class DerivedType : BaseType { }
    public void ManipulateList(List<BaseType> list)
    {
        list.Add(new BaseType());
    }
    ...
    List<DerivedType> objects = new List<DerivedType>();
    objects.Add(new DerivedType());
    ManipulateList(objects);
