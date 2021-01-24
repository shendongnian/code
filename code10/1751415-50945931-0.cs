    public class OrderArticlesAdapter : RecyclerView.Adapter
    {
    	public List<OrderArticleViewModel> listOfOrderArticles;
    
    	public OrderArticlesAdapter(List<OrderArticleViewModel> orderArticles, ....., .....)
    	{
    		listOfOrderArticles = orderArticles;
    	}
    	
    	public OrderArticlesAdapter(List<Invoice> invoices)
    	{
    		listOfOrderArticles = invoices.Select(MapToArticleVM).ToList();
    	}
    	
    	private OrderArticleViewModel MapToArticleVM(Invoice invoice)
    	{
    		return new OrderArticleViewModel
    		{
    			ArticleId = invoice.ArtId,
    			// ...
    		};
    	}
    }
