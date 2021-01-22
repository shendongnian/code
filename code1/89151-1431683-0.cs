    public class BaseType { }
    public class DerivedType : BaseType { }
    public void DumpList(List<BaseType> list)
    {
        foreach (var o in list)
            Debug.WriteLine(o);
    }
    ...
    List<DerivedType> objects = new List<DerivedType>();
    objects.Add(new DerivedType());
    DumpList(objects);
