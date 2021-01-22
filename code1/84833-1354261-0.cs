    public class Foo
    {
        private Type ParentAtCreation = null;
        public Foo()
        {
            ParentAtCreation = (new StackTrace())
                .GetFrame(1)
                .GetMethod()
                .DeclaringType;
        }
    }
