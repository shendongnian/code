    public class EdiPartners : IPartners
    {
        [FaultContract(typeof(ExceptionObject))]
        public Supplier GetPartnerData(string SupplierNumber)
        {
           // Code
        }
    }
