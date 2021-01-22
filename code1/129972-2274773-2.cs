    public IEnumerable<MyClass> Values {
        get {
            using (sync.ReadLock()) {
                foreach (MyClass value in cache.Values)
                    yield return value;
            }
        }
    }
