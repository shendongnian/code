    interface IIsActive {
        bool IsActive { get; set; }
    }
    class A : IIsActive {
        public bool IsActive { get; set; }
    }
    class B : IIsActive {
        public bool IsActive { get; set; }
    }
    
    public class DataAccessBase<T> where T : class, IIsActive {
        public IList<T> GetAllActive() {
        return dataContext.GetTable<T>()
                          .Where(x => x.IsActive)
                          .ToList();
        }
    }
