    public class ClassThatUses
    {
        public Foo Foo { get; set; }
        public void CallPrepare()
        {
            // Foo.Prepare();
            Foo.GetType().GetMethod("Prepare").Invoke(Foo, null);
        }
    }
