    public interface IRepository<T> 
    {
    	    ...
            IList<T> FindAll();
            IList<T> FindBySpec(ISpecification<T> specification);
            T GetById(int id);
    }
    
    public interface ISpecificRepository : IRepository<Specific> 
    {
    	    ...
            IList<Specific> FindBySku(string sku);
            IList<Specific> FindByName(string name);
            IList<Specific> FindByPrice(decimal price);
    }
