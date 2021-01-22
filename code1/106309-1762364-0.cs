    public class ClassThatUses
    {
        public Foo Foo;
        public void CallPrepare()
        {
            // Foo.Prepare();
            Foo.GetType().GetMethod("Prepare").Invoke(Foo, null);
        }
    }
