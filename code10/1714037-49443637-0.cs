    public async void TSReCalculation(int piGroupId, int piIssuerId, DateTime pdFromDate, DateTime ldToDate, int piFormulaId, int piIsProcessedType, int piIsSeriesReStart, int piIsPLCalculate, int piIsIncludeEditedScoreint)
    {
        var returnvalue =await Common.callSpForTS(piGroupId, piIssuerId, pdFromDate, ldToDate, piFormulaId, piIsProcessedType, piIsSeriesReStart, piIsPLCalculate, piIsIncludeEditedScoreint);
    }
    
    public static async List<ResultData> callSpForTS(int piGroupId, int piIssuerId, DateTime pdFromDate, DateTime ldToDate, int piFormulaId, int piIsProcessedType, int piIsSeriesReStart, int piIsPLCalculate, int piIsIncludeEditedScoreint)
    {
                await Task.Run(() =>
                {
                    List<ResultData> ResultList = new List<ResultData>();
                        try
                        {
                            sqlCommand.ExecuteNonQuery();
                            dbModel.ResultData item = new dbModel.ResultData();
                            item.Description= "succesfulll"
                            item.Status = 1;
                            item.BatchId = 100;
                            ResultList.Add(item);
                        }
                        catch (Exception ex)
                        {
                            Common.showMessageBox(ex.Message + "InnerException:" + ex.InnerException, MSG_TYP.Error, "Error Occured");
                        }
                     return ResultList;
                });
            }
    }
