    void SomeFunction<T> (T model) where T : IHasParent
    {
        var parent = model.GetParent();
    }
    public interface IHasParent
    {
    	IHasParent GetParent();
    }
