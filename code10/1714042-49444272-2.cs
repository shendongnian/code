            public async void TSReCalculation(int piGroupId, int piIssuerId, DateTime pdFromDate, DateTime ldToDate, int piFormulaId, int piIsProcessedType, int piIsSeriesReStart, int piIsPLCalculate, int piIsIncludeEditedScoreint)
            {
                var result = await Common.callSpForTS(piGroupId, piIssuerId, pdFromDate, ldToDate, piFormulaId, piIsProcessedType, piIsSeriesReStart, piIsPLCalculate, piIsIncludeEditedScoreint);
            }
    
           
            public static async Task<List<ResultData>> callSpForTS(int piGroupId, int piIssuerId, DateTime pdFromDate, DateTime ldToDate, int piFormulaId, int piIsProcessedType, int piIsSeriesReStart, int piIsPLCalculate, int piIsIncludeEditedScoreint)
            {
                try
                {
                    List<ResultData> myList = new List<ResultData>();
                    sqlCommand.ExecuteNonQuery();
                    dbModel.ResultData item = new dbModel.ResultData();
                    item.Description = "succesfulll";
                    item.Status = 1;
                    item.BatchId = 100;
                    myList.Add(item);
                    return myList;
                }
                catch (Exception ex)
                {
                    Common.showMessageBox(ex.Message + "InnerException:" + ex.InnerException, MSG_TYP.Error, "Error Occured");
                }
            }
