    public void StartTransaction()
            {
                using (var stockMovementCtx = new StockMovementCtxDataContext())
                using (var scope = new TransactionScope())
                {
    
                    var stockMovementItems = from s in stockMovementCtx.spStockMovementForTransaction(TicketID, ItemTypeNo, ItemID, TransactionType,
                                                                                                      FromLocation, ToLocation, Qty, PersonelNo, cuser
                                                                                                      )
                                             select s;
    
    				var item = stockMovementItems.FirstOrDefault()
    				if (item != null)
    				{
    					ReturnCode = (item.ReturnCode;
    				   // MessageBox.Show((item.ToString());
    					ReturnMsg = item.ReturnMessage;
    					TransactionType = item.TransactionType;
    					TicketID = item.TicketID;
