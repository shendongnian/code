    class InMemoryStore<T,U> {
      public override U GetUniqueIdentifier() {
        var generator = generators[typeof(U)] as IUIDGenerator<U>;
        return generator.Create(collection);
      }
    }
