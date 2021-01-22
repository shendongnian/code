    public class FooBar
    {
        public int ReturnInt() { return 0; }
    }
    public FooBar ReturnNullObject()
    {
        return null;
    }
    // Execution code:
    int exceptionalInt = ReturnNullObject().ReturnInt();
