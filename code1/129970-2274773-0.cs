    public IEnumerable<MyClass> Values() {
        using (sync.ReadLock()) {
            foreach (MyClass value in cache.Values)
                yield return value;
            
            yield break;
        }
    }
