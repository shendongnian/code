    public static class BuilderInclusionsForm
    {
        public static BuilderInclusionsForm<T> Create<T>(T product) where T : Product
        {
            return new BuilderInclusionsForm<T>(product);
        }
    }
