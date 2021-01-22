    public class DtoCustomer
    {
        [ExportAttribute(DisplayName = "#", IsVisible = false)]
        public int ID { get; set; }
        [ExportAttribute(DisplayName = "Customer Name", IsVisible = true)]
        public string Name{ get; set; }
        [ExportAttribute(DisplayName = "Customer Surname", IsVisible = true)]
        public string Surname { get; set; }
    }
