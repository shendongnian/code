    static class FooExts
    {
        public List<B> AsB( this Foo foo )
        {
            return list.GetListOfA().AsB();
        }
    }
    List<B> bList = foo.AsB();
