    public class EntityCollectionBase<T> : List<T> where T : EntityBase, new()
    {
        public EntityBase Load()
        {
            return new T().Create(10);
        }
    }
    public abstract class EntityBase
    {
        public abstract EntityBase Create(int a);
    }
