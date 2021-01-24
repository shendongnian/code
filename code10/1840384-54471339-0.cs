    using System.Collections.Generic;
    
    public interface IEntity
    {
        void Save<T>(List<T> entities) where T : IEntity;
    }
    
    public class Job : IEntity
    {
        void IEntity.Save<T>(List<T> entities) { }
    }
    
    public class TargetImpl : IEntity
    {
        void IEntity.Save<T>(List<T> entities) { }
    }
