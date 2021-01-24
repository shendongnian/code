    [DelimitedRecord("|")]
    public class Orders
    {
        public int OrderID;
        public string NotImportant1;
        public string NotImportant2;
        public string NotImportant3;
    
        public string CustomerID;
    
        [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
        public DateTime OrderDate;
    
        [FieldConverter(ConverterKind.Decimal, ".")] // The decimal separator is .
        public decimal Freight;
        [FieldOptional, FieldArrayLength(0, 100)]
        public string[] I_DONT_CARE_WHAT_COMES_AFTER_THIS;
    }
