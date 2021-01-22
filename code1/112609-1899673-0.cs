    void SomeFunction<T> (object model) where T : IHasParent
    {
        var parent = (SomeClass<T>)model.GetParent();
    }
    public interface IHasParent
    {
        void GetParent();
    }
