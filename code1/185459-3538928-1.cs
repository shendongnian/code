    public interface IRepository
    {
        object Get(int id);
        IEnumerable<object> GetAll();
    }
