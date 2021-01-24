    public class GetAllOrdersByUserQuery :  : IRequest<OrdeListViewModel>
    {
        // if OrderAcceptedByUser is true else OrderCreatedByUser = false
        public bool AcceptedOrCreatedBit { get; set; } 
        public string UserId { get; set; }
    }
