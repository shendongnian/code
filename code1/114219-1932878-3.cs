    public class Order
    {
    	public int ID {get;set;}
    	public DateTime OrderDate {get;set;}
    	public List<OrderDetail> Items {get;set;}
    	
    	public int SaveOrUpdate(){}
    	public static Order Get(int id){}
    	public static List<Order> Get(){}
    	public bool Delete(){}
    }
    
    public class OrderDetail
    {
    	public int OrderID{get;set;}
    	public string ProductName{get;set;}
    	public double Price{get;set;}{get;set;}
    	public Order Order {get;}
    
    	public static void Save(TransactionContext tc, int masterID, List<OrderDetail> items){}
    	public static void Delete(TransactionContext tc, int masterID){}
    	public static List<OrderDetail> Get(TransactionContext tc, int masterID){}
    }
