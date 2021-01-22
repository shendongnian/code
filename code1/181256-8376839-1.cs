    public static class Store
    {
        private static IDocumentStore store = createStore();
        private static EmbeddableDocumentStore createStore()
        {
            var returnStore = new EmbeddableDocumentStore();
            returnStore.DataDirectory = @"./PersistedData";
            returnStore.Initialize();
            return returnStore;
        }
        public static xxx Read(string key)
        {
            using (var session = store.OpenSession())
            {
         
                var anEntity = session.Query<xxx>().
                    Where(item => item.key == key).Single();
                return anEntity;
            }
        }
        public static void Write(xxx)
        {
            using (var session = store.OpenSession())
            {
                session.Store(xxx);
                session.SaveChanges();
            }
        }
    }
