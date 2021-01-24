    public class SummaryDTO {
    	public int itemNo { get; set; }
    	public string buyerNo { get; set; }
    	public string sellerNo { get; set; }
    	public string itemDesc { get; set; }
    }
    var result = dataContext.Q_TBL_INVENTORY_SUMMARIES
    		.SqlQuery("SELECT itemNo,
    						   group_concat(buyerNo) buyerNo,
    						   group_concat(sellerNo) sellerNo,
    						   itemDesc
    				  FROM summary
    				  GROUP BY itemNo").ToList<SummaryDTO>();
    		
