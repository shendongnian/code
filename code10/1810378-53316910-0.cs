    class Measurement
    {
         public int Id {get; set;}
         public int File {get; set;}
         // measurement identification
         public string Tool {get; set;}
         public string Product {get; set;}
         ...
         // you wanted to add a Count, instead add a previous version
         public int PreviousMeasurementId {get; set;}   // 0 if no previous measurement
    }
