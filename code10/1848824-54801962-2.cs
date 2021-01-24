    public class MyDataService : BaseDataService
    {
    	public IList<Test> ReadTest()
    	{
    		IList<Test> testList = new List<Test>();
    		DbCommand selectCommand = null;
    
    		selectCommand = SqlDatabase.GetStoredProcCommand("[dbo].[CSP_Test_SelectAll]");
    
    		using (DataSet result = SqlDatabase.ExecuteDataSet(selectCommand))
    		{
    			if (result.Tables[0].Rows.Count > 0)
    			{
    				DataTable dataTable = result.Tables[0];
    				feesList = dataTable.ConvertTo<Test>();
    			}
    		}
    
    		return testList;
    	}
    }
