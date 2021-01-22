    public class CustomerDownloadInfo
    {
    	private string sku;
    	private readonly ICustomer customer;
    	
    	public CustomerDownloadInfo(ICustomer Customer){
    		customer = Customer;
    	}
    	
    	public void AttachSku(string Sku){
    		sku = Sku;
    	}
    	
    	public string Sku{
    		get { return sku; }
    	}
    	
    	public string Link{
    		get{    
    			// etc... etc...          
    		}
    	}
    }
