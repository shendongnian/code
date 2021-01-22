    public interface IIsActive
    {
        bool IsActive { get; set; }
    }
    public class DataAccessBase<T> where T : IIsActive
