    public interface IRepository
    {
        public object Get(int id); // or object id
        public void Save(object obj);
    }
    public class CustomerRepository : IRepository
    {
        public object Get(int id) { // implementation }
        public void Save(object obj) { // implementation }
    }
