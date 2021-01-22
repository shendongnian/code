    public class AccountRepository
    {
    	public Account GetAccountByID(int accountID)
    	{
    		Account result = null;
    
    		using(MyDataContext dc = new ConnectionFactory.GetConnection(Databases.DB1))
    		{
    			result = dc.Accounts.Where(a=>a.AccountID == accountID).FirstOrDefault();
    		}
    		
    		//result is null...go to the other database to get an Account
    		if(result == null)
    		{
    			using(MyDataContext dc = new ConnectionFactory.GetConnection(Databases.DB2))
    			{
    				result = dc.Accounts.Where(a=>a.AccountID == accountID).FirstOrDefault();
    			}
    		}
    
    		return result;
    
    		}
    	}
    }
