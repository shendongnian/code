    public class BankDataGridForm : CatalogDataGridForm<BankDataGridControl>
    { 
    }
    public class BankDataEntryForm : CatalogDataEntryForm<BankDataEntryControl>
    {
    }
    
    public class BankManager : CatalogManager<BankDataEntryForm, BankDataGridForm,CatalogBusinessObject>
    {
    	public BankManager()
    	{
    
    	}
    }
