    public interface IMyDeferredClass
    {
        int MethodReturningInt(int parameter);
        int IntegerProperty { get; set; }
        int this[int index] { get; }
        event EventHandler SomeEvent;
    }
