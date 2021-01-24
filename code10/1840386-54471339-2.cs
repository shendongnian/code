    public class Job : IEntity
    {
        public void Save<T>(List<T> entities) where T : IEntity { }
    }
    
    public class TargetImpl : IEntity
    {
        public void Save<T>(List<T> entities) where T : IEntity { }
    }
