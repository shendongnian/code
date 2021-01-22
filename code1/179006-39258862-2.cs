    // internal because it should only be used in the data source project and not elsewhere
    internal sealed class DbTankReading {
       int TankReadingsID { get; set; }
       DateTime? ReadingDateTime { get; set; }
       int ReadingFeet { get; set; }
       int ReadingInches { get; set; }
       string MaterialNumber { get; set; }
       string EnteredBy { get; set; }
       decimal ReadingPounds { get; set; }
       int MaterialID { get; set; }
       bool Submitted { get; set; }
    }
