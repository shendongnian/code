    public abstract class FooRepository<T> : IRepository<T> where T: IEntity
        {
            private List<T> _data;
    
            public List<T> GetAll()
            {
                return this._data;
            }
    
            T IRepository<T>.GetById(int id)
            {
                return this.GetAll().Single(c => c.ID == id);
            }
        }
    
        public class BarRepository : FooRepository<Bar>
        {
        }
    
        public interface IEntity
        {
            int ID { get; set; }
        }
    
        public interface IRepository<T>
        {
            List<T> GetAll();
            T GetById(int id);
        }
    
        public class Bar : IEntity
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
