    void SomeFunction<T> (object model) where T : IHasParent
    {
        var parent = ((T)model).GetParent();
    }
    public interface IHasParent
    {
    	object GetParent();
    }
