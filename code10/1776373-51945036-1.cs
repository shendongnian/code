    public static class LazyDefault
    {
        public static Lazy<TNew> New<TNew>() where TNew : new()
        {
            return new Lazy<TNew>(() => new TNew());
        }
    }
