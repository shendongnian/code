    public class CloudInfoQuery : IQueryable<CloudContentModel>
    {
        private string _accessToken;
    	private List<CloudContentModel> _cloudContents = new List<CloudContentModel>();
    
        public Type ElementType => typeof(CloudContentModel);
    
        public Expression Expression
        {
            get;
            private set;
        }
    
        public IQueryProvider Provider
        {
            get;
            private set;
        }
    
        internal CloudInfoQuery(string accessToken)
        {
            _accessToken = accessToken;
            Provider = new CloudInfoProvider(accessToken, _cloudContents);
            Expression = _cloudContents.AsQueryable().Expression;
        }
    
        internal CloudInfoQuery(string accessToken, IQueryProvider provider, Expression expression) : this(accessToken)
        {
            Provider = provider;
            Expression = expression;
        }
    
        public IEnumerator<CloudContentModel> GetEnumerator()
        {
            return Provider.Execute<IEnumerable<CloudContentModel>>(Expression).GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public class CloudInfoProvider : IQueryProvider
    {
    	private string _accessToken;
    	private List<CloudContentModel> _cloudContents = null;
    
    	public CloudInfoProvider(string accessToken, List<CloudContentModel> cloudContent)
    	{
    		_accessToken = accessToken;
    		_cloudContents = cloudContent;
    	}
    
    	public IQueryable CreateQuery(Expression expression)
    	{
    		return new CloudInfoQuery(_accessToken, this, expression);
    	}
    
    	public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    	{
    		return (IQueryable<TElement>)new CloudInfoQuery(_accessToken, this, expression);
    	}
    
    	public object Execute(Expression expression)
    	{
            _cloudContent.Clear();
    		_cloudContent.AddRange(GetContentFromWebService(expression));
    		return cloudContents.AsQueryable().Provider.CreateQuery(expression):
    	}
    
    	public TResult Execute<TResult>(Expression expression)
    	{
    		return (TResult)Execute(expression);
    
    	}
    }
