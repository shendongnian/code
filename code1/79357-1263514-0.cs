    static class AExts
    {
        public List<B> AsB( this List<A> list )
        {
            return list.Cast<B>().ToList();
        }
    }
    List<B> bList = foo.GetListOfA().AsB();
