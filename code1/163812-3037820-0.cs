    public class MyDataSource
    {
    	DataClasses1DataContext db = new DataClasses1DataContext(".\\SQLExpress");
    
    	public IQueryable<Order> AllOrders
    	{
    		get { return db.Orders; }
    	}
    
    	public IQueryable<OrderDetails> OrderDetails
    	{
    		get
    		{
    			// define your custom query here
    		}
    	}
    }
----------
    MyDataSource dataSource = new MyDataSource();
    dataGridView2.DataSource = new BindingSource()
    {
    	DataSource = dataSource.AllOrders;
    	DataMember = dataSource.OrderDetails;
    };
