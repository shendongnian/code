    public class AccountRepository
    {
    	public Account GetAccountByID(int accountID)
    	{
    		Account result = null;
    
    		using(MyDataContext dc = new ConnectionFactory.GetConnection())
    		{
    			result = dc.Accounts.Where(a=>a.AccountID == accountID).FirstOrDefault();
    		}
    
    		return result;
    	}
    }
