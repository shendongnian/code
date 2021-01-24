     public ActionResult GetUPCs()
            {
               // List<upcReturnData> upcDetails = db.RebateAssignedUpc.ToList();
    
                var result = db.RebateAssignedUpc.Select(x => new
                {
                   id= x.Id,
                   upc=x.Upc
                   
                }).ToList();
    
            
                return Json( new { dataReturned = result });
    
            }
    public partial class upcReturnData
    {
        public int id { get; set; }
        public string upc { get; set; }
    }
