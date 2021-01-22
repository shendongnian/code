    public interface IIsActive
    {
        public bool IsActive
    }
    public class DataAccessBase<T> where T : IIsActive
