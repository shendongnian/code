    public class GenericoRepositorio<T> : IGenericoRepositorio<T> where T : class
    {
        protected readonly ObjectSet<T> ObjetoSet;
        protected readonly ModeloContainer Contexto;
        public GenericoRepositorio(ModeloContainer contexto)
        {
            Contexto = contexto;
            ObjetoSet = Contexto.CreateObjectSet<T>();
        }
        public T Carregar(int id)
        {
            object objeto;
            Contexto.TryGetObjectByKey(GetEntityKey(ObjetoSet, id), out objeto);
            return (T)objeto;
        }
        private static EntityKey GetEntityKey<T>(ObjectSet<T> objectSet, object keyValue) where T : class
        {
            var entitySetName = objectSet.Context.DefaultContainerName + "." + objectSet.EntitySet.Name;
            var keyPropertyName = objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
            var entityKey = new EntityKey(entitySetName, new[] { new EntityKeyMember(keyPropertyName, keyValue) });
            return entityKey;
        }
    }
