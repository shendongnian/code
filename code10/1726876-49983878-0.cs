    class TestGenerics
    {
        public IEnumerable<T> Query<T>() where T : new()
        {
            return Enumerable.Repeat(new T(), 10);
        }
    }
