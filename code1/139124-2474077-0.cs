    public class FooRepository
    {
        private MyDataContext context;
        public FooRepository(MyDataContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            this.context = context;
        }
        public void Add(Foo foo)
        {
            context.FooTable.InsertOnSubmit(foo);
        }
        public void Update(Foo foo)
        {
            Foo oldFoo = context.FooTable.Single(f => f.ID == foo.ID);
            oldFoo.Bar = foo.Bar;
            oldFoo.Baz = foo.Baz;
        }
    }
