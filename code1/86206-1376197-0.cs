    public class QuotePart
    {
      public int ProdId{get;set;}
      public string ItemId{get;set;}
      public string Quantity{get;set;}
    }
    
    
    model.Parts = from qi in quoteItem.All()
                  where qi.quote_id == quoteid
                  select new QuotePart{ ProdId = qi.prodid, ItemId = qi.itemid,Quantity=qi.qty};
