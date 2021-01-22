    [Serializable]
    public class EntityDataSource : ObjectDataSource
    {
        [NonSerialized] private EntityContext dataContext;
        // etc...
    }
