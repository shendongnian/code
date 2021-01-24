    [DelimitedRecord((","))]
    public class Employee
    {
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string DepartmentPosition;
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string ParentDepartmentPosition;
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string JobTitle;
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Role;
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Location;
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string NameLocation;
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string EmployeeStatus;
    }
