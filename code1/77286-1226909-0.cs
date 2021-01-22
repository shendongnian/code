    public class FooRepository
    {
        readonly QueryCache<MyModelDataContext> q = 
            new QueryCache<MyModelDataContext>(new MyModelDataContext());
    }
