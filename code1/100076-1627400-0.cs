    private List<T> MakeList<T>(T itemOftype)
    {
        List<T> newList = new List<T>();
        return newList;
    } 
    //create a fake type for anonymous type
    var stockType = new {StockID = 0, StockUserId =0, Ticker = string.Empty};
    var listOfStocks = MakeList(stockType);
    //fill listOfStocks with your method
    var listOfStocks = from st in brdc.tb_dStocks
                     join su in brdc.tb_rStockUsers on st.StockID equals su.StockID
                     where su.UserID == userRec.UserID
                     select new { st.StockID, su.StockUserID, st.Ticker };
    //now you have a direct access to all anonymous properties  
