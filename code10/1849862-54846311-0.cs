    void MyFunction()
    {
        KnownType result = GetFirst<KnownType>();
        AddElement(result);
    }
    public class KnownType: SomeClass, ISomeInterface {...}
    public T GetFirst<T>() => this.objects.OfType<T>().First();
