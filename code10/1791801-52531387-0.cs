    var query = from summary in dataContext.Q_TBL_INVENTORY_SUMMARIES
    				group summary by new
    				{
    					itemNo = summary.itemNo,
    					itemDesc = summary.itemDesc
    
    				} into grp
    				select new
    				{
    					itemNo = grp.Key.itemNo ,
    					buyerNo = string.Join(",", grp.Select(i => i.buyerNo)),
    					sellerNo = string.Join(",", grp.Select(i => i.sellerNo)),
    					itemDesc = grp.Key.itemDesc
    				};
