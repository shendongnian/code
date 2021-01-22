    public static partial class EntityIds<TId1, TId2> {
        public class Association<TEntity1, TEntity2>
          where TEntity1 : Entity<TId1>
          where TEntity2 : Entity<TId2>
        {
          // ...
        }
    }
