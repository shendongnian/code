    public abstract class FooRepository<T> where T: IEntity
        {
            private List<T> _data;
    
            public List<T> GetAll()
            {
                return this._data;
            }
    
            T GetById(int id)
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
    
     
        public class Bar : IEntity
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
