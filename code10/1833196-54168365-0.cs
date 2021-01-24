    public partial class ActionContext : DbContext
    {
        public IEnumerable<T> SelectAll<T>() where T: class
        {
            return this.Set<T>().AsEnumerable();
        }
    }
