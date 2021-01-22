    public class OrderBuilder : Builder<Order>
    {
        private string _referenceNumber;
        private DateTime? _approvedDateTime;
        public override Order Create()
        {
            return new Order(_referenceNumber, _approvedDateTime);
        }
        public string ReferenceNumber
        {
            get { return _referenceNumber; }
            set { SetField(ref _referenceNumber, value); }
        }
        public DateTime? ApprovedDateTime
        {
            get { return _approvedDateTime; }
            set { SetField(ref _approvedDateTime, value); }
        }
    }
