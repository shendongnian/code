    public interface ISolrOperations<T> 
    {
        SqlQuery<T> Execute();
    }
    
    public interface ISolrOperationsAdapter
    {
        IEnumerable<Base> Execute();
    }
    
    //Idealy you have interfaces
    public class Base { }
    public class Class1 : Base { }
    public class Class2 : Base { }	
    
    public abstract class SolrOperationsAdapter : ISolrOperationsAdapter
    {
        protected SolrOperationsAdapter()
        {
        }
    
        public IEnumerable<Base> Execute()
        {
            return ExecuteImpl();
        }
    
        protected abstract IEnumerable<Base> ExecuteImpl();
    }
    
    
    public class GenericSolrOperationsAdapter<T> : SolrOperationsAdapter
    {
        private readonly ISolrOperations<T> _solrOperations;
    
        public static ISolrOperationsAdapter From(ISolrOperations<T> solrOperations)
        {
            return new GenericSolrOperationsAdapter<T>(solrOperations);
        }
    
        protected GenericSolrOperationsAdapter(ISolrOperations<T> solrOperations)
            : base()
        {
            _solrOperations = solrOperations;
        }
    
        //If you define interfaces you can return return IEnumerable<IInterface>
        protected override IEnumerable<Base> ExecuteImpl()
        {
            //here when you get Query convert to IEnumerable or collection of Base instances???
            return Enumerable.Empty<Base>();
        }
    }
        
