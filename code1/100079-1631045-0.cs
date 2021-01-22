    private class StockInfo
            {
                public int StockID { get; set; }
                public int StockUserID { get; set; }
                public string Ticker { get; set; }
    
                public StockInfo(int stockID, int stockUserID, string ticker)
                {
                    StockID = stockID;
                    StockUserID = stockUserID;
                    Ticker = ticker;
                }
            }          
      
    BaxRunDataContext brdc = new BaxRunDataContext();
                    IEnumerable<StockInfo> stocks = from st in brdc.tb_dStocks
                                 join su in brdc.tb_rStockUsers on st.StockID equals su.StockID
                                 where su.UserID == userRec.UserID
                                 select new StockInfo(st.StockID, su.StockUserID, st.Ticker);
    
                    cboStocks.ItemsSource = stocks;
                    cboStocks.DisplayMemberPath = "Ticker";
