    public class COFXCompanyNumber
    {
        public string CustomerNumber { get; set; }
        public string OptionalField { get; set; }
        public string Value { get; set; }
    }
    public class ARCustomers
    {
        public string CustomerNumber { get; set; }
        public string ShortName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string ContactName { get; set; }
        public string ContactsFax { get; set; }
        public string ContactsPhone { get; set; }
        public string Country { get; set; }
        public int CreditLimitCustomerCurrency { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string FaxNumber { get; set; }
        public string GroupCode { get; set; }
        public string OnHold { get; set; }
        public string PhoneNumber { get; set; }
        public string PrintStatements { get; set; }
        public string Salesperson1 { get; set; }
        public System.DateTime StartDate { get; set; }
        public string StateProvince { get; set; }
        public string Terms { get; set; }
        public string TerritoryCode { get; set; }
        public string ZipPostalCode { get; set; }
        public int NumberOfOptionalFields { get; set; }
        public string ProcessCommandCode { get; set; }
        public IList<COFXCompanyNumber> CustomerOptionalFieldValues { get; set; }
    }
