    // covariant part, T is used only as return value
    // ISomeModelRead is not the best name of course
    public interface ISomeModelRead<out T> where T : IBasicModel {
        T GetById(string id);
        IEnumerable<T> GetAll();
    }
    // the rest of interface, also implementing covariant part
    public interface ISomeModelAbstract<T> : ISomeModelRead<T> where T : IBasicModel  {
        bool Save(T model);
        bool Update(string id, T model);
        bool Delete(string id);
    }
