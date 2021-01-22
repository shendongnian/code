    public class Order
    {
        public string ReferenceNumber { get; private set; }
        public DateTime? ApprovedDateTime { get; private set; }
        public void Approve()
        {
            this.ApprovedDateTime = DateTime.Now;
        }
    }
