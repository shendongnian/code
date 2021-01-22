    public class OrderBuilder : Builder<Order>
    {
        string _referenceNumber;
        DateTime? _approvedDateTime;
        public override Order Create()
        {
            return new Order(_referenceNumber, _approvedDateTime);
        }
        public string ReferenceNumber
        {
            get { return _referenceNumber; }
            set
            {
                if(value != _referenceNumber)
                {
                    _referenceNumber = value;
                    ClearInstance();
                }
            }
        }
        public DateTime? ApprovedDateTime
        {
            get { return _approvedDateTime; }
            set
            {
                if(value != _approvedDateTime)
                {
                    _approvedDateTime = value;
                    ClearInstance();
                }
            }
        }
    }
