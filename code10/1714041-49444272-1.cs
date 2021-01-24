    private static List<ResultData > ResultList = new List<ResultData >();
    public static async Task<ResultList> callSpForTS(int piGroupId, int piIssuerId, DateTime pdFromDate, DateTime ldToDate, int piFormulaId, int piIsProcessedType, int piIsSeriesReStart, int piIsPLCalculate, int piIsIncludeEditedScoreint)
    {
    	try
    	{
    		ResultList myList = new ResultList()
    		sqlCommand.ExecuteNonQuery();
    		dbModel.ResultData item = new dbModel.ResultData();
    		item.Description= "succesfulll"
    		item.Status = 1;
    		item.BatchId = 100;
    		myList.Add(item);
    		return await myList.ToListAsync()
    	}
    	catch (Exception ex)
    	{
    		Common.showMessageBox(ex.Message + "InnerException:" + ex.InnerException, MSG_TYP.Error, "Error Occured");
    	}
    }
