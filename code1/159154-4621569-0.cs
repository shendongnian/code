    using System.Data.Services.Common;
    [DataServiceKey("ComputerName")]
    public class Computer 
    {
        public string ComputerName { get; set; }
        public string Location { get; set; } }
    }
    [DataServiceKey("PrinterName")]
    public class Printer
    {
        public string PrinterName { get; set; }
        public string Location { get; set; } }
    }
