    public class PurchaseRequest
    {       
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public virtual DateTime Created { get; set; } = DateTime.Now;
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public virtual DateTime? Assigned { get; set; }
        ...
    }
    
    public class PurchaseRequestService
    {
        public Task Assign()
        {
            ...
            purchaseRequest.Assigned = DateTime.Now;
            ...
            
            await _dataContext.SaveChangesAsync();
        }
    }
